using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using YANLib;
using static System.Text.Json.JsonSerializer;

namespace Yan.Demo.Web.Middlewares;

public class ExceptionHandlerMiddleware
{
    #region Fields
    private readonly RequestDelegate _requestDelegate;
    #endregion

    #region Constructors
    public ExceptionHandlerMiddleware(RequestDelegate requestDelegate) => _requestDelegate = requestDelegate;
    #endregion

    #region Methods
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _requestDelegate(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = ex.Errors.FirstOrDefault().ErrorCode.ParseInt(400);
            context.Response.ContentType = "application/json";
            var errors = ex.Errors.Select(x => new
            {
                x.PropertyName,
                x.ErrorMessage
            });
            var result = Serialize(new
            {
                Errors = errors
            });
            await context.Response.WriteAsync(result);
        }
    }
    #endregion
}
