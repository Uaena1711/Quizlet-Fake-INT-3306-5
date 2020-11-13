using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Quizlet_Fake.Managers
{
    public interface ICourseInfoOfUserAppService :
        ICrudAppService< //Defines CRUD methods
            CourseInfoOfUserDto, //Used to show 
            Guid, //Primary key of the  entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CourseInfoOfUserCreateUpdateDto>
    {
    }
}
