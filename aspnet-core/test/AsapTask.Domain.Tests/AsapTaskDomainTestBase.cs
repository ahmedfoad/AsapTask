using Volo.Abp.Modularity;

namespace AsapTask;

/* Inherit from this class for your domain layer tests. */
public abstract class AsapTaskDomainTestBase<TStartupModule> : AsapTaskTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
