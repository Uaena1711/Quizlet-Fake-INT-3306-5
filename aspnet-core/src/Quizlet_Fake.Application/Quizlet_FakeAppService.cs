using System;
using System.Collections.Generic;
using System.Text;
using Quizlet_Fake.Localization;
using Volo.Abp.Application.Services;

namespace Quizlet_Fake
{
    /* Inherit your application services from this class.
     */
    public abstract class Quizlet_FakeAppService : ApplicationService
    {
        protected Quizlet_FakeAppService()
        {
            LocalizationResource = typeof(Quizlet_FakeResource);
        }
    }
}
