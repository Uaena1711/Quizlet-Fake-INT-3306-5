using Microsoft.EntityFrameworkCore;
using Quizlet_Fake.Courses;
using Quizlet_Fake.Learns;
using Quizlet_Fake.Lessons;
using Quizlet_Fake.Managers;
using Quizlet_Fake.Participations;
using Quizlet_Fake.Users;
using Quizlet_Fake.Words;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Quizlet_Fake.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See Quizlet_FakeMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class Quizlet_FakeDbContext : AbpDbContext<Quizlet_FakeDbContext>
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Word> Words { get; set; }

        public DbSet<ParticipationPermission> ParticipationPermissions { get; set; }
        public DbSet<Learn> Learns { get; set; }
        public DbSet<CourseInfoOfUser> CourseInfoOfUsers { get; set; }
        public DbSet<LessonInfoOfUser> LessonInfoOfUsers { get; set; }


        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside Quizlet_FakeDbContextModelCreatingExtensions.ConfigureQuizlet_Fake
         */

        public Quizlet_FakeDbContext(DbContextOptions<Quizlet_FakeDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                /* Configure mappings for your additional properties
                 * Also see the Quizlet_FakeEfCoreEntityExtensionMappings class
                 */
            });

            /* Configure your own tables/entities inside the ConfigureQuizlet_Fake method */

            builder.ConfigureQuizlet_Fake();
        }
    }
}
