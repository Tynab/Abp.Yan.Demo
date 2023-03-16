using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Yan.Demo.Web;

[Dependency(ReplaceServices = true)]
public class DemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Demo";
}
