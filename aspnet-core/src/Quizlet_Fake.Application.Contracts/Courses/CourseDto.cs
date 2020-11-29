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
        public Guid UserId { get; private set; }

        public string AuthorName { set; get; }

        public DateTime PublishDate { get; set; }
        public int LessonNumber { get; set; }
        public float Price { get; set; }
    }
}
