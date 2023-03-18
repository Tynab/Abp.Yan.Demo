using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp.DependencyInjection;
using static System.Console;

namespace Yan.Demo.HttpApi.Client.ConsoleTestApp;

public class ClientDemoService : ITransientDependency
{
    #region Fields
    private readonly IProfileAppService _profileAppService;
    #endregion

    #region Constructors
    public ClientDemoService(IProfileAppService profileAppService) => _profileAppService = profileAppService;
    #endregion

    #region Methods
    public async Task RunAsync()
    {
        var output = await _profileAppService.GetAsync();
        WriteLine($"UserName : {output.UserName}");
        WriteLine($"Email    : {output.Email}");
        WriteLine($"Name     : {output.Name}");
        WriteLine($"Surname  : {output.Surname}");
    }
    #endregion
}
