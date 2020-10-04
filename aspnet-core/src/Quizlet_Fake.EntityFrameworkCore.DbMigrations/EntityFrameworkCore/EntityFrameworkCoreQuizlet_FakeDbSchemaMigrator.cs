using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quizlet_Fake.Data;
using Volo.Abp.DependencyInjection;

namespace Quizlet_Fake.EntityFrameworkCore
{
    public class EntityFrameworkCoreQuizlet_FakeDbSchemaMigrator
        : IQuizlet_FakeDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreQuizlet_FakeDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the Quizlet_FakeMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<Quizlet_FakeMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}