using Volo.Abp.Modularity;

namespace AsapTask;

[DependsOn(
    typeof(AsapTaskDomainModule),
    typeof(AsapTaskTestBaseModule)
)]
public class AsapTaskDomainTestModule : AbpModule
{

}
