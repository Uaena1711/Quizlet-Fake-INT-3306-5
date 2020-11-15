using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Quizlet_Fake.Courses
{
    public class Course : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Password { get; set; }
        public  Guid UserId { get; private set; }
        public DateTime PublishDate { get; set; }
        public float Price { get; set; }

        public int wordnumber { get; set; } = 0;
    }
}
