using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Quizlet_Fake.Data
{
    /* This is used if database provider does't define
     * IQuizlet_FakeDbSchemaMigrator implementation.
     */
    public class NullQuizlet_FakeDbSchemaMigrator : IQuizlet_FakeDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}