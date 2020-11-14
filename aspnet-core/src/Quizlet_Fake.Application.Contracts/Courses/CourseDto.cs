using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Quizlet_Fake.Courses
{
    public class CourseDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        //public string Password { get; set; }
        public Guid UserId { get;  set; }
        public DateTime PublishDate { get; set; }
        public float Price { get; set; }
        public int wordnumber { get; set; }
    }
}
