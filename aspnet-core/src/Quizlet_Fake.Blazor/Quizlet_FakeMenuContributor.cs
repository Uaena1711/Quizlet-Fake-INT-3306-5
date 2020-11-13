using System.Threading.Tasks;
using Quizlet_Fake.Localization;
using Volo.Abp.UI.Navigation;

namespace Quizlet_Fake.Blazor
{
    public class Quizlet_FakeMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<Quizlet_FakeResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "Quizlet_Fake.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
