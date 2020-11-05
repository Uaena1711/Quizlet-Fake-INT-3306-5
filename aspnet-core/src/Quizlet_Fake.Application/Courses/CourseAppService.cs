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
    public class CourseAppService :
        CrudAppService<
            Course,//Defines CRUD methods
            CourseDto, //Used to show 
            Guid, //Primary key of the  entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CourseCreateUpdateDto>, //Used to create/update 
        ICourseAppService, ITransientDependency
    {
        //public IAbpSession AbpSession { get; set; }
        public CourseAppService(IRepository<Course, Guid> repository ,ICurrentUser currentUser, IRepository<ParticipationPermission> y) : base(repository)
        {
            this._currentUser = currentUser;
            this._repository = repository;
            this._parRepo = y;
        }
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<Course, Guid> _repository;
        private readonly IRepository<ParticipationPermission> _parRepo;
        public async override Task<CourseDto> CreateAsync(CourseCreateUpdateDto input)
        {
            input.UserId =(Guid)  _currentUser.Id;
            //input.UserId = AbpSession.UserId;
            var x = base.CreateAsync(input);
            var rs = await x;
            var per = new CoursesPermissionCreateUpdateDto();
            per.UserId = input.UserId;
            per.CourseId = rs.Id;
            var ins = ObjectMapper.Map<CoursesPermissionCreateUpdateDto, ParticipationPermission>(per);
            await _parRepo.InsertAsync(ins);
            return rs;
        }

        public  List<Course> GetCoursesOfUser (String? text)
        {
            var course = new List<Course>();
            Guid id = (Guid)_currentUser.Id;
            if (text == null)
            {

                course = _repository.Where(p => p.UserId == id).ToList();
            }
            else
            {
                course = _repository.Where(p => p.UserId == id && p.Name.Contains(text)).ToList();
            }
            return course;
        }
        public async Task<ListResultDto<CourseDto>> GetListssss(PagedAndSortedResultRequestDto input, String? text)
        {
            if (text == null)
            {
                List<Course> course =  await _repository.GetListAsync();

                List<CourseDto> courdto = ObjectMapper.Map<List<Course>, List<CourseDto>>(course);
                return new ListResultDto<CourseDto>(courdto);
            }
            else
            {
               var  course = _repository.Where( p => p.Name.Contains(text)).ToList();

                List<CourseDto> courdto = ObjectMapper.Map<List<Course>, List<CourseDto>>(course);
                return new ListResultDto<CourseDto>(courdto);
            }
        }

        public  Task DeleteAsyncc(Guid id)
        {
            var course =  _repository.FirstOrDefault(x =>x.Id == id);
            if (course.UserId == _currentUser.Id)
            {
                return   base.DeleteAsync(id);
            }
            return base.DeleteAsync(new Guid());
             
        }
        public override Task<CourseDto> UpdateAsync(Guid id, CourseCreateUpdateDto input)
        {
            

            var course = _repository.FirstOrDefault(x => x.Id == id);
            if (course.UserId == _currentUser.Id)
            {
                return base.UpdateAsync(id, input);
            }
            return base.UpdateAsync(new Guid(), input);
        }

    }
}
