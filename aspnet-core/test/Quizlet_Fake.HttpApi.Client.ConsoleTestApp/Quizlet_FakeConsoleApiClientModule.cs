using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Quizlet_Fake.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(Quizlet_FakeHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class Quizlet_FakeConsoleApiClientModule : AbpModule
    {
        
    }
}
