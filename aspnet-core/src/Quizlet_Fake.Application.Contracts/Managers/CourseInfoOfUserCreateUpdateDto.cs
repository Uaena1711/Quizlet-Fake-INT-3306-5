using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Quizlet_Fake.Managers
{
    public class CourseInfoOfUserCreateUpdateDto : AuditedEntityDto<Guid>
    {
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public int Progress { get; set; }

    }
}
