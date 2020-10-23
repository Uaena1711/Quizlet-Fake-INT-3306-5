using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Quizlet_Fake.LogCoursesPermission
{
    public class CoursesPermissionDto :AuditedEntityDto<Guid>
    {
        public Guid CourseId { get; set; }

        public Guid UserId { get; set; }
    }
}
