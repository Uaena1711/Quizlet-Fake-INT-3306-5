namespace Quizlet_Fake.Permissions
{
    public static class Quizlet_FakePermissions
    {
        public const string GroupName = "Quizlet_Fake";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
        public static class Courses
        {
            public const string Default = GroupName + ".Courses";
            
        }
        public static class Lesson
        {
            public const string Default = GroupName + ".Lesson";
            
        }
        public static class Word
        {
            public const string Default = GroupName + ".Word";
           
        }
    }
}