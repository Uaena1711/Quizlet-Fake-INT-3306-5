using Quizlet_Fake.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Quizlet_Fake.Permissions
{
    public class Quizlet_FakePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(Quizlet_FakePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(Quizlet_FakePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<Quizlet_FakeResource>(name);
        }
    }
}
