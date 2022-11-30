using System.Threading.Tasks;

namespace HD.HRM.Data;

public interface IHRMDbSchemaMigrator
{
    Task MigrateAsync();
}
