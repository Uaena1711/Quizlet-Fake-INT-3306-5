using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Quizlet_Fake.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class Quizlet_FakeMigrationsDbContextFactory : IDesignTimeDbContextFactory<Quizlet_FakeMigrationsDbContext>
    {
        public Quizlet_FakeMigrationsDbContext CreateDbContext(string[] args)
        {
            Quizlet_FakeEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<Quizlet_FakeMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new Quizlet_FakeMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Quizlet_Fake.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
