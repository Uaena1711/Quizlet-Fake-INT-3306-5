using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Quizlet_Fake.Words
{
    public class WordDto : AuditedEntityDto<Guid>
    {  
        public string Name { get; set; }
       
        public string VN { get; set; }
       
        public string EN { get; set; }


        public Guid LessonId { get; private set; }
    }
}
