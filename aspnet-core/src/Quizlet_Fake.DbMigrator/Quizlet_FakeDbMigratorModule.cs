using Quizlet_Fake.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Quizlet_Fake.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(Quizlet_FakeEntityFrameworkCoreDbMigrationsModule),
        typeof(Quizlet_FakeApplicationContractsModule)
        )]
    public class Quizlet_FakeDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
