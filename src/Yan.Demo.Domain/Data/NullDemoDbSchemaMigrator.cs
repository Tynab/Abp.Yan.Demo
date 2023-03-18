using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using static System.Threading.Tasks.Task;

namespace Yan.Demo.Data;

public class NullDemoDbSchemaMigrator : IDemoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync() => CompletedTask;
}
