using AsapTask.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AsapTask.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AsapTaskEntityFrameworkCoreModule),
    typeof(AsapTaskApplicationContractsModule)
    )]
public class AsapTaskDbMigratorModule : AbpModule
{
}
