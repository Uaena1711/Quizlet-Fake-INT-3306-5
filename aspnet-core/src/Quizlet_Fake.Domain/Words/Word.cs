using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Quizlet_Fake.Words
{
    public class Word : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string VN { get; set; }
        public string EN { get; set; }

        public Guid LessonId { get; private set; }

    }
}
