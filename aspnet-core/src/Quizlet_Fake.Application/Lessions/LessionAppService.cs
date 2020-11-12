
using Quizlet_Fake.Courses;
using Quizlet_Fake.Lessons;
using Quizlet_Fake.Lesssion;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Volo.Abp.Users;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using Quizlet_Fake.Participations;

namespace Quizlet_Fake.Lessions
{
    public class LessionAppService :
         CrudAppService<
             Lesson,//Defines CRUD methods
             LessionDto, //Used to show 
             Guid, //Primary key of the  entity
             PagedAndSortedResultRequestDto, //Used for paging/sorting
             LessionCreateorUpdateDto>, //Used to create/update 
         ILessionAppService, ITransientDependency
    {
        //public IAbpSession AbpSession { get; set; }
        public LessionAppService(IRepository<Lesson, Guid> repository, ICurrentUser currentUser, IRepository<Course, Guid> repo,  IRepository<ParticipationPermission, Guid> x) : base(repository)
        {
            this._currentUser = currentUser;
            this._repository = repository;
            this.courseRepo = x;
        }
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<Lesson, Guid> _repository;
        private readonly IRepository<ParticipationPermission, Guid> courseRepo;
        public override Task<LessionDto> CreateAsync(LessionCreateorUpdateDto input)
        {
            var course = courseRepo.FirstOrDefault(x => x.CourseId == input.CourseId);
            if (course != null)
            {

                if (course.UserId == (Guid)_currentUser.Id)
                {
                    return base.CreateAsync(input);
                }
            }
            //input.UserId = AbpSession.UserId;
            return base.CreateAsync(new LessionCreateorUpdateDto());
        }

        public List<Lesson> GetLessionOfCourses(Guid id)
        {
            var lession = new List<Lesson>();
            Guid currentId = (Guid)_currentUser.Id;
            var course = courseRepo.Where(x => x.CourseId == id).Where(x=> x.UserId == currentId).FirstOrDefault();
            if(course != null)
            {
                lession = _repository.Where(x => x.CourseId == id).ToList();
                return lession;
            }


            return lession;
        }

        public override Task DeleteAsync(Guid id)
        {
            
            var lesson = _repository.FirstOrDefault(x => x.Id == id);
            var course = courseRepo.FirstOrDefault(x => x.CourseId == lesson.CourseId);
            if (course != null)
            {

                if (course.UserId == _currentUser.Id)
                {
                    return base.DeleteAsync(id);
                }
            }
            return base.DeleteAsync(new Guid());

        }
        public override Task<LessionDto> UpdateAsync(Guid id, LessionCreateorUpdateDto input)
        {


            var lesson = _repository.FirstOrDefault(x => x.Id == id);
            var course = courseRepo.FirstOrDefault(x => x.CourseId == lesson.CourseId);
            if (course != null)
            {

                if (course.UserId == _currentUser.Id)
                {
                    return base.UpdateAsync(id, input);
                }
            }
            return base.UpdateAsync(new Guid(), input);
        }




    }
}
