using Yan.Demo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Yan.Demo;

[DependsOn(
    typeof(DemoEntityFrameworkCoreTestModule)
    )]
public class DemoDomainTestModule : AbpModule
{

}
