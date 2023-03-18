using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Yan.Demo.Pages;

public class Index_Tests : DemoWebTestBase
{
    [Fact]
    public async Task Welcome_Page() => await GetResponseAsStringAsync("/").ShouldNotBeNull();
}
