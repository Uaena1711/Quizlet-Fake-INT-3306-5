using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Quizlet_Fake.Managers
{
    public class CourseInfoOfUserDto: AuditedEntityDto<Guid>
    {
        public Guid CourseId { get; set; }

        public Guid UserId { get; set; }

        public int Progress { get; set; }
    }
}
