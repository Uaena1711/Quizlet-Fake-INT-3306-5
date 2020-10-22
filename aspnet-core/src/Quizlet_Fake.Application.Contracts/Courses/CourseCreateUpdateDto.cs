using System;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;
using System.Text;

namespace Quizlet_Fake.Courses
{
    public class CourseCreateUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        public Guid UserId { get;  set; }
        public float Price { get; set; }
    }
}
