using System;
using System.Collections.Generic;
using System.Text;
using Yan.Demo.Localization;
using Volo.Abp.Application.Services;

namespace Yan.Demo;

/* Inherit your application services from this class.
 */
public abstract class DemoAppService : ApplicationService
{
    protected DemoAppService()
    {
        LocalizationResource = typeof(DemoResource);
    }
}
