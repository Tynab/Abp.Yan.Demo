using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using static System.IO.Directory;
using static System.IO.Path;
using static Yan.Demo.EntityFrameworkCore.DemoEfCoreEntityExtensionMappings;

namespace Yan.Demo.EntityFrameworkCore;

public class DemoDbContextFactory : IDesignTimeDbContextFactory<DemoDbContext>
{
    public DemoDbContext CreateDbContext(string[] args)
    {
        Configure();
        return new DemoDbContext(new DbContextOptionsBuilder<DemoDbContext>().UseSqlServer(BuildConfiguration().GetConnectionString("Default")).Options);
    }

    private static IConfigurationRoot BuildConfiguration() => new ConfigurationBuilder().SetBasePath(Combine(GetCurrentDirectory(), "../Yan.Demo.DbMigrator/")).AddJsonFile("appsettings.json", optional: false).Build();
}
