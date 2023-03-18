using System.Collections.Generic;
using System.Security.Claims;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;
using static Volo.Abp.Security.Claims.AbpClaimTypes;

namespace Yan.Demo.Security;

[Dependency(ReplaceServices = true)]
public class FakeCurrentPrincipalAccessor : ThreadCurrentPrincipalAccessor
{
    #region Fields
    protected override ClaimsPrincipal GetClaimsPrincipal() => GetPrincipal();
    #endregion

    #region Constructors
    private ClaimsPrincipal _principal;
    #endregion

    #region Methods
    private ClaimsPrincipal GetPrincipal()
    {
        if (_principal == null)
        {
            lock (this)
            {
                _principal ??= new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(UserId,"2e701e62-0953-4dd3-910b-dc6cc93ccb0d"),
                    new Claim(UserName,"admin"),
                    new Claim(Email,"admin@abp.io")
                }));
            }
        }
        return _principal;
    }
    #endregion
}
