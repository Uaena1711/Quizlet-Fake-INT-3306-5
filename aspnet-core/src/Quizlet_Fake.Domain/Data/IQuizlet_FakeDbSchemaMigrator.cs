using System.Threading.Tasks;

namespace Quizlet_Fake.Data
{
    public interface IQuizlet_FakeDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
