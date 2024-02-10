using Volo.Abp.Settings;

namespace AsapTask.Settings;

public class AsapTaskSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AsapTaskSettings.MySetting1));
    }
}
