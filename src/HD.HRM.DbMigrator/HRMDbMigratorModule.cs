using HD.HRM.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace HD.HRM.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HRMEntityFrameworkCoreModule),
    typeof(HRMApplicationContractsModule)
    )]
public class HRMDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
