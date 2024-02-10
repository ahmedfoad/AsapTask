using AsapTask.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AsapTask.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AsapTaskController : AbpControllerBase
{
    protected AsapTaskController()
    {
        LocalizationResource = typeof(AsapTaskResource);
    }
}
