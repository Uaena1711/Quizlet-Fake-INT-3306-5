using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Quizlet_Fake.Participations
{
    public class ParticipationPermission : AuditedAggregateRoot<Guid>
    {
        public Guid CourseId { get; set; }

        public Guid UserId { get; set; }
    }
}
