using System;
using System.Collections.Generic;
using System.Text;

namespace Quizlet_Fake.LogCoursesPermission
{
    public class StatusResult
    {
        public BaseResult Result { get; set; } = BaseResult.NeedPermission; 
       
    }

    public enum BaseResult
    {
        NeedPermission,
        NoPermission,
        Ok
    }
}
