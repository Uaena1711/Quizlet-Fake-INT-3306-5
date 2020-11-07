using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc;
using Quizlet_Fake.Courses;
using Quizlet_Fake.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Quizlet_Fake.Managers
{
    public class CourseInfoOfUserAppService :
        CrudAppService<
            CourseInfoOfUser,//Defines CRUD methods
            CourseInfoOfUserDto, //Used to show 
            Guid, //Primary key of the  entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CourseInfoOfUserCreateUpdateDto>, //Used to create/update 
        ICourseInfoOfUserAppService, ITransientDependency
    {
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<CourseInfoOfUser, Guid> _repository;
        private readonly IRepository<Course, Guid> _Courserepository;

        public CourseInfoOfUserAppService(IRepository<CourseInfoOfUser, Guid> repository,IRepository<Course,Guid>courserepo,/* IRepository<Course, Guid> Courserepository,*/
            ICurrentUser currentUser)
             : base(repository)
        {
            this._currentUser = currentUser;
            this._repository = repository;
            this._Courserepository = courserepo;
        }
        public override Task<CourseInfoOfUserDto> CreateAsync(CourseInfoOfUserCreateUpdateDto input)
        {
            input.Progress = 0;
            return base.CreateAsync(input);
        }

        /* public  Task DeleteForCreator(CourseInfoOfUserCreateUpdateDto input)
         {
             Guid id_coureseCreator =(Guid) this._Courserepository.FirstOrDefault(x => x.CreatorId == input.CourseId).CreatorId; //layra_ id nguoi tao course 

             if ((Guid)_currentUser.Id == id_coureseCreator)

             {
                 return base.DeleteAsync(input.Id);
             }
             else
             {
                 return new Task(null);
             }
         }*/

        [HttpDelete]
        public  Task OutCourse(Guid IdCOurse )
        {

            var courseuser = _repository.FirstOrDefault(x => x.CourseId == IdCOurse && x.UserId == _currentUser.Id);
            if ((Guid)_currentUser.Id == courseuser.UserId)

            {
                return base.DeleteAsync(courseuser.Id);
            }
            else
            {
                return new Task(null);
            }
        }

        //layra danh sach hoc cua minh hoc
       


        public async Task<List<CourseInfoOfUserDto>> GetmyLearningCourse ()
        {
            var Dtos = from couruse in _repository
                       join coursereal in _Courserepository on couruse.CourseId equals coursereal.Id
                       where couruse.UserId == _currentUser.Id
                       select new  { couruse, coursereal};
            var queryresult = await AsyncExecuter.ToListAsync(Dtos);

            var result = queryresult.Select(x =>
               {
                   var dto = ObjectMapper.Map<CourseInfoOfUser, CourseInfoOfUserDto>(x.couruse);
                   dto.coursename = x.coursereal.Name;

                   return dto;
               });

                return new List<CourseInfoOfUserDto>(result);
                
        }
    }
}
