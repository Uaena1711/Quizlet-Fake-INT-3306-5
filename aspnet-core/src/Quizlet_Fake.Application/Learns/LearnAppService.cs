using Quizlet_Fake.Courses;
using Quizlet_Fake.Lessons;
using Quizlet_Fake.Managers;
using Quizlet_Fake.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Quizlet_Fake.Learns
{
     public class LearnAppService :
        CrudAppService<
            Learn,//Defines CRUD methods
            LearnDto, //Used to show 
            Guid, //Primary key of the  entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            LearnCreateUpdateDto>, //Used to create/update 
        ILearnAppService, ITransientDependency
    {
        //public IAbpSession AbpSession { get; set; }
        public LearnAppService(IRepository<Learn, Guid> repository,
            IRepository<CourseInfoOfUser, Guid> _courserepository,
            IRepository<LessonInfoOfUser, Guid> _lessonrepository,
            IRepository<Course, Guid> _course_rea_repository,
            IRepository<Word, Guid> _word_rea_repository,
        IRepository<Lesson, Guid> _lesson_rea_repository,
        ICurrentUser currentUser) : base(repository)
        {
            this._currentUser = currentUser;
            this._repository = repository;
            this._lessonrepository = _lessonrepository;
            this._courserepository = _courserepository;
               this._course_real_repository = _course_rea_repository;
            this._lesson_rea_repository = _lesson_rea_repository;
            this._word_rea_repository = _word_rea_repository;
        }
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<Learn, Guid> _repository;
        private readonly IRepository<LessonInfoOfUser, Guid> _lessonrepository;
        private readonly IRepository<CourseInfoOfUser, Guid> _courserepository;
        private readonly IRepository<Course, Guid> _course_real_repository;
        private readonly IRepository<Lesson, Guid> _lesson_rea_repository;
        private readonly IRepository<Word, Guid> _word_rea_repository;
        public  Task<LearnDto> UpdateLevel(Guid id, LearnCreateUpdateDto input,bool d)
        {
            if(d)
            {
                input.Level += 1;
                input.DateReview = DateTime.Now.AddHours(4 * input.Level);
            }
            else
            {
                if (input.Level > 1)
                {
                    input.Level -= 1;

                }
                input.DateReview = DateTime.Now.AddHours(4 * input.Level);
            }
            //update tien do cua lesson
            var word = _word_rea_repository.FirstOrDefault(x => x.Id == input.WordId);
            Guid lsid = word.LessonId;
            this.UpdateProgressLessontable(lsid);
            return base.UpdateAsync(id, input);
        }
        public void UpdateProgressLessontable(Guid idlesson)
        {
            Guid userid = (Guid)_currentUser.Id;

            var x = _lessonrepository.FirstOrDefault(k => k.UserId == userid && k.LessonId == idlesson);

            List<Learn> l = _repository.Where(x => x.LessonId == idlesson).ToList();
            int sum = 0;
            foreach(Learn a in l)
            {
                
                sum += a.Level;

            }
            x.Progress = (int)sum * 100 / (5 * l.Count);
            _lessonrepository.UpdateAsync(x);

        }
        public async Task<List<LearnDto>> GetMyWortdList(Guid learnid)
        {
            await CheckGetListPolicyAsync();

            Guid myid = (Guid)_currentUser.Id;
            var query = from word1 in _repository
                        join word in _word_rea_repository on word1.WordId equals word.Id
                        where word1.LessonId == learnid && word1.UserId == myid
                        select new { word1, word };

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var DTos = queryResult.Select(x =>
            {
                var dto = ObjectMapper.Map<Learn, LearnDto>(x.word1);
                dto.VN = x.word.VN;
                dto.EN = x.word.EN;
                return dto;
            }).ToList();


            return new List<LearnDto>(DTos);
        }


    }
}
