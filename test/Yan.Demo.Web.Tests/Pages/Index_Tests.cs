using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Yan.Demo.Pages;

public class Index_Tests : DemoWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
