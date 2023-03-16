using Microsoft.AspNetCore.Builder;
using Yan.Demo.Web.Middlewares;

namespace Yan.Demo.Web.Extensions;

public static class DemoModuleApplicationBuilderExtension
{
    public static IApplicationBuilder UseDemoModuleExceptionHandler(this IApplicationBuilder app) => app.UseMiddleware<ExceptionHandlerMiddleware>();
}
