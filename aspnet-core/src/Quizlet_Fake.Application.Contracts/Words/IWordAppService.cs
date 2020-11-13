using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Quizlet_Fake.Words
{
    public interface IWordAppService :
         ICrudAppService< //Defines CRUD methods
            WordDto, //Used to show 
            Guid, //Primary key of the  entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            WordCreateOrUpdateDto> //Used to create/update 
    {
    }
}
