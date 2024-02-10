using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AsapTask;

[Dependency(ReplaceServices = true)]
public class AsapTaskBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AsapTask";
}
