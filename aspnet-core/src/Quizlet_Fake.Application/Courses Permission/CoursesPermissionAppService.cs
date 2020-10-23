using Abp.Runtime.Session;
using Quizlet_Fake.LogCoursesPermission;
using Quizlet_Fake.Participations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Quizlet_Fake.Courses
{
    public class CoursesPermissionAppService :
        CrudAppService<
            ParticipationPermission,//Defines CRUD methods
            CoursesPermissionDto, //Used to show 
            Guid, //Primary key of the  entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CoursesPermissionCreateUpdateDto>, //Used to create/update 
        ICoursesPermissionAppService, ITransientDependency
    {
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<ParticipationPermission, Guid> _repository;
        private readonly IRepository<Course, Guid> CoursesRepository;
        public CoursesPermissionAppService(IRepository<ParticipationPermission, Guid> repository, ICurrentUser currentUser, IRepository<Course, Guid> xrepo) : base(repository)
        {
            this._currentUser = currentUser;
            this._repository = repository;
            this.CoursesRepository = xrepo;

        }

        public StatusResult CheckCoursesPermission(Guid id)
        {
            var res = new StatusResult() { Result = BaseResult.NeedPermission };
            var x = CoursesRepository.FirstOrDefault(x => x.Id == id);
            if(x.CreatorId == (Guid) _currentUser.Id)
            {
                 res.Result = BaseResult.Ok;
                return res;
            }
            if(x.Password == null)
            {
                res.Result = BaseResult.Ok;
                return res;
            }
            var y = _repository.Where(x => x.CourseId == id).Where(x => x.UserId == _currentUser.Id).FirstOrDefault();
            if(y == null) { 
                res.Result = BaseResult.NeedPermission;
                return res;
            }

            res.Result = BaseResult.Ok;
            return res;

            
        }

        public async Task<StatusResult> AddPermission (Guid id, String? pass) 
        {
            var res =  new StatusResult() { Result = BaseResult.NeedPermission };
            var x = CoursesRepository.FirstOrDefault(x => x.Id == id);
            if(x.Password == pass)
            {
                var news = new CoursesPermissionCreateUpdateDto();
                news.UserId =(Guid)_currentUser.Id;
                news.CourseId = id;
                res.Result = BaseResult.Ok;
                var ins = ObjectMapper.Map<CoursesPermissionCreateUpdateDto, ParticipationPermission>(news);
                await _repository.InsertAsync(ins);
                
            }
            else
            {
                res.Result = BaseResult.NoPermission;
                
            }
            return res;
        }

      
        public override Task<CoursesPermissionDto> UpdateAsync(Guid id, CoursesPermissionCreateUpdateDto input)
        {
            var x = _repository.FirstOrDefault(x => x.Id == id);
            if (x.UserId == _currentUser.Id)
            {
                return base.UpdateAsync(id, input);
            }
            return base.UpdateAsync(new Guid(), input);
        }
    }
}
