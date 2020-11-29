using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Quizlet_Fake.Lesssion
{
    public class LessionDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public Guid CourseId { get; private set; }
        public int wordnumber { get; set; }


        public int progress { get; set; }
    }
}
