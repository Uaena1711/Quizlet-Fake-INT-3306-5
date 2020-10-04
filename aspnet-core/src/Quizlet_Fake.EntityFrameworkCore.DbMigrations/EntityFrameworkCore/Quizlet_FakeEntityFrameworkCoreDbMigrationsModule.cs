using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Quizlet_Fake.EntityFrameworkCore
{
    [DependsOn(
        typeof(Quizlet_FakeEntityFrameworkCoreModule)
        )]
    public class Quizlet_FakeEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<Quizlet_FakeMigrationsDbContext>();
        }
    }
}
