using Quizlet_Fake.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Quizlet_Fake.Permissions
{
    public class Quizlet_FakePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(Quizlet_FakePermissions.GroupName, L("Permission:Courses"));

            //Define your own permissions here. Example:
            //myGroup.AddPermission(Quizlet_FakePermissions.MyPermission1, L("Permission:MyPermission1"));
            var coursesPermission = myGroup.AddPermission(Quizlet_FakePermissions.Courses.Default, L("Permission:GetCourses"));
            var lessonPermission = myGroup.AddPermission(Quizlet_FakePermissions.Lesson.Default, L("Permission:GetLessons"));
            var wordPermission = myGroup.AddPermission(Quizlet_FakePermissions.Word.Default, L("Permission:GetWords"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<Quizlet_FakeResource>(name);
        }
    }
}
