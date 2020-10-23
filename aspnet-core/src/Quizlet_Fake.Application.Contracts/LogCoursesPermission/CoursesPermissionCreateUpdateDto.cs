using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quizlet_Fake.LogCoursesPermission
{
    public class CoursesPermissionCreateUpdateDto
    {
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
