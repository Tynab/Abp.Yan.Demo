using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Yan.Demo.EntityFrameworkCore;

namespace Yan.Demo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DemoEntityFrameworkCoreModule),
    typeof(DemoApplicationContractsModule)
    )]
public class DemoDbMigratorModule : AbpModule { }
