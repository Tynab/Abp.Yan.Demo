using Volo.Abp.Modularity;
using Yan.Demo.EntityFrameworkCore;

namespace Yan.Demo;

[DependsOn(
    typeof(DemoEntityFrameworkCoreTestModule)
    )]
public class DemoDomainTestModule : AbpModule { }
