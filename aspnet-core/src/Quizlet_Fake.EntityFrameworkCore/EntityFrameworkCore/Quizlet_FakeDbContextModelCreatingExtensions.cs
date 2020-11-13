using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Quizlet_Fake.Courses;
using Quizlet_Fake.Learns;
using Quizlet_Fake.Lessons;
using Quizlet_Fake.Managers;
using Quizlet_Fake.Participations;
using Quizlet_Fake.Words;
using Quizlet_Fake.Users;

namespace Quizlet_Fake.EntityFrameworkCore
{
    public static class Quizlet_FakeDbContextModelCreatingExtensions
    {
        public static void ConfigureQuizlet_Fake(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(Quizlet_FakeConsts.DbTablePrefix + "YourEntities", Quizlet_FakeConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
            builder.Entity<Course>(b =>
            {
                b.ToTable(Quizlet_FakeConsts.DbTablePrefix + "Courses", Quizlet_FakeConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                // b.ConfigureExtraProperties();

                // ADD THE MAPPING FOR THE RELATION
              //  b.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId).IsRequired();
            });
            builder.Entity<Lesson>(b =>
            {
                b.ToTable(Quizlet_FakeConsts.DbTablePrefix + "Lessons", Quizlet_FakeConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
               

                // ADD THE MAPPING FOR THE RELATION
                b.HasOne<Course>().WithMany().HasForeignKey(x => x.CourseId).IsRequired();
            });
            builder.Entity<Word>(b =>
            {
                b.ToTable(Quizlet_FakeConsts.DbTablePrefix + "Words", Quizlet_FakeConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
               
                // ADD THE MAPPING FOR THE RELATION
                b.HasOne<Lesson>().WithMany().HasForeignKey(x => x.LessonId).IsRequired();
            });
            builder.Entity<ParticipationPermission>(b =>
            {
                b.ToTable(Quizlet_FakeConsts.DbTablePrefix + "ParticipationPermissions", Quizlet_FakeConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
              //  b.ConfigureExtraProperties();

                // ADD THE MAPPING FOR THE RELATION
                b.HasOne<Course>().WithMany().HasForeignKey(x => x.CourseId).IsRequired();
              //  b.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId).IsRequired();

            });

            builder.Entity<Learn>(b =>
            {
                b.ToTable(Quizlet_FakeConsts.DbTablePrefix + "Learns", Quizlet_FakeConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
              //  b.ConfigureExtraProperties();

                // ADD THE MAPPING FOR THE RELATION
                b.HasOne<Word>().WithMany().HasForeignKey(x => x.WordId).IsRequired();
              //  b.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId).IsRequired();

            });

            builder.Entity<CourseInfoOfUser>(b =>
            {
                b.ToTable(Quizlet_FakeConsts.DbTablePrefix + "CourseInfoOfUsers", Quizlet_FakeConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
              //  b.ConfigureExtraProperties();

                // ADD THE MAPPING FOR THE RELATION
                b.HasOne<Course>().WithMany().HasForeignKey(x => x.CourseId).IsRequired();
               // b.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId).IsRequired();

            });

            builder.Entity<LessonInfoOfUser>(b =>
            {
                b.ToTable(Quizlet_FakeConsts.DbTablePrefix + "LessonInfoOfUsers", Quizlet_FakeConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
              //  b.ConfigureExtraProperties();

                // ADD THE MAPPING FOR THE RELATION
                b.HasOne<Lesson>().WithMany().HasForeignKey(x => x.LessonId).IsRequired();
               // b.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId).IsRequired();

            });
        }
    }
}