using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quizlet_Fake.Words
{
    public class WordCreateOrUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string VN { get; set; }
        [Required]
        public string EN { get; set; }
        [Required]

        public Guid LessonId { get; private set; }
    }
}
