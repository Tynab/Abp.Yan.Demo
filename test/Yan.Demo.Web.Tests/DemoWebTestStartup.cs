using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Yan.Demo;

public class DemoWebTestStartup
{
    public static void ConfigureServices(IServiceCollection services) => services.AddApplication<DemoWebTestModule>();

    public static void Configure(IApplicationBuilder app) => app.InitializeApplication();
}
