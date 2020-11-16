using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Quizlet_Fake.Words
{
    public class Word : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Vn { get; set; }
        public string En { get; set; }

        public Guid LessonId { get; private set; }

    }
}
