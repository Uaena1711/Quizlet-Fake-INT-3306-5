using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Quizlet_Fake.LogCoursesPermission
{
    public interface ICoursesPermissionAppService :
         ICrudAppService< //Defines CRUD methods
            CoursesPermissionDto, //Used to show 
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CoursesPermissionCreateUpdateDto> //Used to create/update a book
    {

    }
}
