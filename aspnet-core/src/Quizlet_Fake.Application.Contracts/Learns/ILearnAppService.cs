using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Quizlet_Fake.Learns
{
    public interface ILearnAppService :
        ICrudAppService< //Defines CRUD methods
          LearnDto, //Used to show 
            Guid, //Primary key of the  entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            LearnCreateUpdateDto> //Used to create/update 
    {
    }
}
