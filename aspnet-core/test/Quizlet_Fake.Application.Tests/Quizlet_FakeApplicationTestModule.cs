using Volo.Abp.Modularity;

namespace Quizlet_Fake
{
    [DependsOn(
        typeof(Quizlet_FakeApplicationModule),
        typeof(Quizlet_FakeDomainTestModule)
        )]
    public class Quizlet_FakeApplicationTestModule : AbpModule
    {

    }
}