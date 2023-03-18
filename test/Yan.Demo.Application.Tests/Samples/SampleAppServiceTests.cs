using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Xunit;

namespace Yan.Demo.Samples;

public class SampleAppServiceTests : DemoApplicationTestBase
{
    #region Fields
    private readonly IIdentityUserAppService _userAppService;
    #endregion

    #region Constructors
    public SampleAppServiceTests() => _userAppService = GetRequiredService<IIdentityUserAppService>();
    #endregion

    #region Methods
    [Fact]
    public async Task Initial_Data_Should_Contain_Admin_User()
    {
        //Act
        var result = await _userAppService.GetListAsync(new GetIdentityUsersInput());
        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(u => u.UserName == "admin");
    }
    #endregion
}
