using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Quizlet_Fake.Managers
{
    public class CourseInfoOfUser : AuditedAggregateRoot<Guid>
    {
        public Guid CourseId { get; set; }

        public Guid UserId { get; set; }

        public int Progress { get; set; }
        //=sobaihoc*tiendo cua moi bai hoc /so bai
        
    }
}
