using Quizlet_Fake.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Quizlet_Fake
{
    [DependsOn(
        typeof(Quizlet_FakeEntityFrameworkCoreTestModule)
        )]
    public class Quizlet_FakeDomainTestModule : AbpModule
    {

    }
}