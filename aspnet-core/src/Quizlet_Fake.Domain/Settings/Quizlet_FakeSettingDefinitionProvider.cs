using Volo.Abp.Settings;

namespace Quizlet_Fake.Settings
{
    public class Quizlet_FakeSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(Quizlet_FakeSettings.MySetting1));
        }
    }
}
