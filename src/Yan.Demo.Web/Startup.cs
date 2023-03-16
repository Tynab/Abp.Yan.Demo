using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Yan.Demo.Web.Middlewares;

namespace Yan.Demo.Web;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        //services.AddControllers().AddFluentValidation();
        services.AddControllers();
        //services.AddFluentValidation();
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
    }

    public void Configure(IApplicationBuilder app)
    {
        _ = app.UseMiddleware<ExceptionHandlerMiddleware>();
        _ = app.UseStaticFiles();
        _ = app.UseEndpoints(x => x.MapControllers());
    }
}
