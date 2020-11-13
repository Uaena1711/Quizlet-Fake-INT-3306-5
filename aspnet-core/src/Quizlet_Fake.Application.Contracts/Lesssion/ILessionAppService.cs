using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Quizlet_Fake.Lesssion
{
    public interface ILessionAppService :
         ICrudAppService< //Defines CRUD methods
            LessionDto, //Used to show 
            Guid, //Primary key of the  entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            LessionCreateorUpdateDto> //Used to create/update 
    {
    }
}
