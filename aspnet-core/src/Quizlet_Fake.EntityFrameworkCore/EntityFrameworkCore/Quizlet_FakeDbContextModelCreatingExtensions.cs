using Microsoft.EntityFrameworkCore;
using Volo.Abp;

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
        }
    }
}