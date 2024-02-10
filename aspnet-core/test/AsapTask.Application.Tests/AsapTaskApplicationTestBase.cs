using Volo.Abp.Modularity;

namespace AsapTask;

public abstract class AsapTaskApplicationTestBase<TStartupModule> : AsapTaskTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
