using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Yan.Demo.Data;

namespace Yan.Demo.EntityFrameworkCore;

public class EntityFrameworkCoreDemoDbSchemaMigrator : IDemoDbSchemaMigrator, ITransientDependency
{
    #region Fields
    private readonly IServiceProvider _serviceProvider;
    #endregion

    #region Constructors
    public EntityFrameworkCoreDemoDbSchemaMigrator(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;
    #endregion

    #region Implements
    public async Task MigrateAsync() => await _serviceProvider.GetRequiredService<DemoDbContext>().Database.MigrateAsync();
    #endregion
}
