using System.Threading.Tasks;

namespace AsapTask.Data;

public interface IAsapTaskDbSchemaMigrator
{
    Task MigrateAsync();
}
