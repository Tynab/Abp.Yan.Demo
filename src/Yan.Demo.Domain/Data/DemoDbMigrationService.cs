using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using static System.Diagnostics.Process;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Runtime.InteropServices.OSPlatform;
using static System.Runtime.InteropServices.RuntimeInformation;
using static Volo.Abp.Identity.IdentityDataSeedContributor;

namespace Yan.Demo.Data;

public class DemoDbMigrationService : ITransientDependency
{
    #region Properties
    public ILogger<DemoDbMigrationService> Logger { get; set; }
    #endregion

    #region Fields
    private readonly IDataSeeder _dataSeeder;
    private readonly IEnumerable<IDemoDbSchemaMigrator> _dbSchemaMigrators;
    private readonly ITenantRepository _tenantRepository;
    private readonly ICurrentTenant _currentTenant;
    #endregion

    #region Constructors
    public DemoDbMigrationService(IDataSeeder dataSeeder, IEnumerable<IDemoDbSchemaMigrator> dbSchemaMigrators, ITenantRepository tenantRepository, ICurrentTenant currentTenant)
    {
        _dataSeeder = dataSeeder;
        _dbSchemaMigrators = dbSchemaMigrators;
        _tenantRepository = tenantRepository;
        _currentTenant = currentTenant;
        Logger = NullLogger<DemoDbMigrationService>.Instance;
    }
    #endregion

    #region Methods
    public async Task MigrateAsync()
    {
        if (AddInitialMigrationIfNotExist())
        {
            return;
        }
        Logger.LogInformation("Started database migrations...");
        await MigrateDatabaseSchemaAsync();
        await SeedDataAsync();
        Logger.LogInformation($"Successfully completed host database migrations.");
        var migratedDatabaseSchemas = new HashSet<string>();
        foreach (var tenant in await _tenantRepository.GetListAsync(includeDetails: true))
        {
            using (_currentTenant.Change(tenant.Id))
            {
                if (tenant.ConnectionStrings.Any())
                {
                    var tenantConnectionStrings = tenant.ConnectionStrings.Select(s => s.Value).ToList();
                    if (!migratedDatabaseSchemas.IsSupersetOf(tenantConnectionStrings))
                    {
                        await MigrateDatabaseSchemaAsync(tenant);
                        _ = migratedDatabaseSchemas.AddIfNotContains(tenantConnectionStrings);
                    }
                }
                await SeedDataAsync(tenant);
            }
            Logger.LogInformation("Successfully completed {name} tenant database migrations.", tenant.Name);
        }
        Logger.LogInformation("Successfully completed all database migrations.");
        Logger.LogInformation("You can safely end this process...");
    }

    private async Task MigrateDatabaseSchemaAsync(Tenant tenant = null)
    {
        Logger.LogInformation("Migrating schema for {info} database...", tenant == null ? "host" : tenant.Name + " tenant");
        foreach (var migrator in _dbSchemaMigrators)
        {
            await migrator.MigrateAsync();
        }
    }

    private async Task SeedDataAsync(Tenant tenant = null)
    {
        Logger.LogInformation("Executing {info} database seed...", tenant == null ? "host" : tenant.Name + " tenant");
        await _dataSeeder.SeedAsync(new DataSeedContext(tenant?.Id).WithProperty(AdminEmailPropertyName, AdminEmailDefaultValue).WithProperty(AdminPasswordPropertyName, AdminPasswordDefaultValue));
    }

    private bool AddInitialMigrationIfNotExist()
    {
        try
        {
            if (!DbMigrationsProjectExists())
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
        try
        {
            if (!MigrationsFolderExists())
            {
                AddInitialMigration();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            Logger.LogWarning("Couldn't determinate if any migrations exist : {message}", e.Message);
            return false;
        }
    }

    private static bool DbMigrationsProjectExists() => GetEntityFrameworkCoreProjectFolderPath() != null;

    private static bool MigrationsFolderExists() => Directory.Exists(Combine(GetEntityFrameworkCoreProjectFolderPath(), "Migrations"));

    private void AddInitialMigration()
    {
        Logger.LogInformation("Creating initial migration...");
        string argumentPrefix;
        string fileName;
        if (IsOSPlatform(OSX) || IsOSPlatform(Linux))
        {
            argumentPrefix = "-c";
            fileName = "/bin/bash";
        }
        else
        {
            argumentPrefix = "/C";
            fileName = "cmd.exe";
        }
        try
        {
            _ = Start(new ProcessStartInfo(fileName, $"{argumentPrefix} \"abp create-migration-and-run-migrator \"{GetEntityFrameworkCoreProjectFolderPath()}\"\""));
        }
        catch (Exception)
        {
            throw new Exception("Couldn't run ABP CLI...");
        }
    }

    private static string GetEntityFrameworkCoreProjectFolderPath() => GetDirectories(Combine(GetSolutionDirectoryPath() ?? throw new Exception("Solution folder not found!"), "src")).FirstOrDefault(x => x.EndsWith(".EntityFrameworkCore"));

    private static string GetSolutionDirectoryPath()
    {
        var currentDirectory = new DirectoryInfo(GetCurrentDirectory());
        while (GetParent(currentDirectory.FullName) != null)
        {
            currentDirectory = GetParent(currentDirectory.FullName);
            if (GetFiles(currentDirectory.FullName).FirstOrDefault(s => s.EndsWith(".sln")) != null)
            {
                return currentDirectory.FullName;
            }
        }
        return null;
    }
    #endregion
}
