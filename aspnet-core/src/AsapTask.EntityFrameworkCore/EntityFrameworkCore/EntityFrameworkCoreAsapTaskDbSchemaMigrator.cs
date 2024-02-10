using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AsapTask.Data;
using Volo.Abp.DependencyInjection;

namespace AsapTask.EntityFrameworkCore;

public class EntityFrameworkCoreAsapTaskDbSchemaMigrator
    : IAsapTaskDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAsapTaskDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AsapTaskDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AsapTaskDbContext>()
            .Database
            .MigrateAsync();
    }
}
