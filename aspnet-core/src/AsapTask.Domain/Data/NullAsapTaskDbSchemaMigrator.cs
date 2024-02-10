using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AsapTask.Data;

/* This is used if database provider does't define
 * IAsapTaskDbSchemaMigrator implementation.
 */
public class NullAsapTaskDbSchemaMigrator : IAsapTaskDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
