using System;
using System.Collections.Generic;
using System.Text;
using AsapTask.Localization;
using Volo.Abp.Application.Services;

namespace AsapTask;

/* Inherit your application services from this class.
 */
public abstract class AsapTaskAppService : ApplicationService
{
    protected AsapTaskAppService()
    {
        LocalizationResource = typeof(AsapTaskResource);
    }
}
