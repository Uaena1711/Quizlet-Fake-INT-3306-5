using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Quizlet_Fake.Learns
{
    public class Learn : AuditedAggregateRoot<Guid>
    {
       

        public Guid UserId { get;  set; }
        public Guid WordId { get;  set; }
        public Guid LessonId { get;  set; }
        public DateTime DateReview { get; set; }

        public DateTime DateofLearn { get; set; }

        public int Level { get; set; }

        public string Note { get; set; }


    }
}
