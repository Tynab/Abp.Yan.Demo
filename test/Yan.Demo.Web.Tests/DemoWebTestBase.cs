using Microsoft.Extensions.Hosting;
using Shouldly;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.TestBase;
using static System.Net.HttpStatusCode;
using static System.Text.Json.JsonSerializer;

namespace Yan.Demo;

public abstract class DemoWebTestBase : AbpAspNetCoreIntegratedTestBase<DemoWebTestStartup>
{
    protected override IHostBuilder CreateHostBuilder() => base.CreateHostBuilder().UseContentRoot(WebContentDirectoryFinder.CalculateContentRootFolder());

    protected virtual async Task<T> GetResponseAsObjectAsync<T>(string url, HttpStatusCode expectedStatusCode = OK) => Deserialize<T>(await GetResponseAsStringAsync(url, expectedStatusCode), new JsonSerializerOptions(JsonSerializerDefaults.Web));

    protected virtual async Task<string> GetResponseAsStringAsync(string url, HttpStatusCode expectedStatusCode = OK) => await (await GetResponseAsync(url, expectedStatusCode)).Content.ReadAsStringAsync();

    protected virtual async Task<HttpResponseMessage> GetResponseAsync(string url, HttpStatusCode expectedStatusCode = OK)
    {
        var response = await Client.GetAsync(url);
        response.StatusCode.ShouldBe(expectedStatusCode);
        return response;
    }
}
