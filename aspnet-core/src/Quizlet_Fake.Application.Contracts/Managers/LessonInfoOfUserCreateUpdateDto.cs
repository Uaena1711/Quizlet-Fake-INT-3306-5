using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Quizlet_Fake.Managers
{
    public class LessonInfoOfUserCreateUpdateDto 
    {
        public Guid LessonId { get; set; }

        public Guid UserId { get; set; }
        //public Guid CourseId { get; private set; }
        public int Progress { get; set; }

    }
}
