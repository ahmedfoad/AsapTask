using Volo.Abp.Modularity;

namespace AsapTask;

[DependsOn(
    typeof(AsapTaskApplicationModule),
    typeof(AsapTaskDomainTestModule)
)]
public class AsapTaskApplicationTestModule : AbpModule
{

}
