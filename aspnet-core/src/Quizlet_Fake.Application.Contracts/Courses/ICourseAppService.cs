using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace Quizlet_Fake.Courses
{
    public interface ICourseAppService :
        ICrudAppService< //Defines CRUD methods
            CourseDto, //Used to show 
            Guid, //Primary key of the  entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CourseCreateUpdateDto> //Used to create/update 
    {
    }
}
