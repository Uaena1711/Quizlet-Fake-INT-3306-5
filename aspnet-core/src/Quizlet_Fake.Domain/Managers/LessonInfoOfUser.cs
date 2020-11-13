using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Quizlet_Fake.Managers
{
    public class LessonInfoOfUser : AuditedAggregateRoot<Guid>
    {
        
        public Guid LessonId { get; set; }

        public Guid UserId { get; set; }

        public int Progress { get; set; }
        //=sotudahoc*level cua moi tu /so bai*5
    }
}
