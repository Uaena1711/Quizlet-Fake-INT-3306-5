using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Quizlet_Fake.Learns
{
    public class LearnDto : AuditedEntityDto<Guid>
    {
        public Guid UserId { get; private set; }
        public Guid WordId { get; private set; }
        public DateTime DateReview { get; set; }

        public DateTime DateofLearn { get; set; }

        public int Level { get; set; }

        public string Note { get; set; }

        public string Vn { get; set; }

        public string En { get; set; }
        public string name { get; set; }

    }
}
