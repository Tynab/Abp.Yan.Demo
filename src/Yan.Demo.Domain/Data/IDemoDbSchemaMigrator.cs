using System.Threading.Tasks;

namespace Yan.Demo.Data;

public interface IDemoDbSchemaMigrator
{
    public Task MigrateAsync();
}
