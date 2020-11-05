using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Quizlet_Fake.Lessons
{
    public class Lesson : AuditedAggregateRoot<Guid>
    {
        
        public string Name { get; set; }

        public Guid CourseId { get; private set; }

    }
}
