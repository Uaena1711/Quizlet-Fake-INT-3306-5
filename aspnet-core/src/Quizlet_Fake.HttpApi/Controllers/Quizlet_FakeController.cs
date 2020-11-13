using Quizlet_Fake.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Quizlet_Fake.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class Quizlet_FakeController : AbpController
    {
        protected Quizlet_FakeController()
        {
            LocalizationResource = typeof(Quizlet_FakeResource);
        }
    }
}