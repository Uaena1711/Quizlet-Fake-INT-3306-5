using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Quizlet_Fake.Managers
{
    public class LessonInfoOfUserDto : AuditedEntityDto<Guid>
    {

        public Guid LessonId { get; set; }

        public Guid UserId { get; set; }

        public int Progress { get; set; }

        public string LessonName { get; set; }
    }
}
