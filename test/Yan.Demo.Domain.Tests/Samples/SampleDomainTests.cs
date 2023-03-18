using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Xunit;

namespace Yan.Demo.Samples;

public class SampleDomainTests : DemoDomainTestBase
{
    #region Fields
    private readonly IIdentityUserRepository _identityUserRepository;
    private readonly IdentityUserManager _identityUserManager;
    #endregion

    #region Constructors
    public SampleDomainTests()
    {
        _identityUserRepository = GetRequiredService<IIdentityUserRepository>();
        _identityUserManager = GetRequiredService<IdentityUserManager>();
    }
    #endregion

    #region Methods
    [Fact]
    public async Task Should_Set_Email_Of_A_User()
    {
        IdentityUser adminUser;
        await WithUnitOfWorkAsync(async () =>
        {
            adminUser = await _identityUserRepository.FindByNormalizedUserNameAsync("ADMIN");
            _ = await _identityUserManager.SetEmailAsync(adminUser, "newemail@abp.io");
            _ = await _identityUserRepository.UpdateAsync(adminUser);
        });
        adminUser = await _identityUserRepository.FindByNormalizedUserNameAsync("ADMIN");
        adminUser.Email.ShouldBe("newemail@abp.io");
    }
    #endregion
}
