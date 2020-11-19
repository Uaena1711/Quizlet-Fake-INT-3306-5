using Abp.Runtime.Session;
using Quizlet_Fake.Courses;
using Quizlet_Fake.Learns;
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

namespace Quizlet_Fake.Managers
{
    public class LessonInfoOfUserAppService :
        CrudAppService<
            LessonInfoOfUser,//Defines CRUD methods
            LessonInfoOfUserDto, //Used to show 
            Guid, //Primary key of the  entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            LessonInfoOfUserCreateUpdateDto>, //Used to create/update 
        ILessonInfoOfUserAppService, ITransientDependency
    {
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<LessonInfoOfUser, Guid> _repository;
        private readonly IRepository<Learn, Guid> _learnrepository;
        private readonly IRepository<Word, Guid> _wordrepository;
        private readonly IRepository<Lesson, Guid> _lesrepository;

        public LessonInfoOfUserAppService(IRepository<LessonInfoOfUser, Guid> repository, IRepository<Learn, Guid> Learnrepository,
            IRepository<Word, Guid> Wordrepository, IRepository<Lesson, Guid> lesrepository,

            ICurrentUser currentUser)
             : base(repository)
        {
            this._currentUser = currentUser;
            this._repository = repository;
            this._learnrepository = Learnrepository;
            this._wordrepository = Wordrepository;
            this._lesrepository = lesrepository;
        }

        //khibam vao hoc lesson
        public override Task<LessonInfoOfUserDto> CreateAsync(LessonInfoOfUserCreateUpdateDto input)
        {
            input.Progress = 0;
            input.UserId = (Guid)_currentUser.Id;
            
            return base.CreateAsync(input);
        }
       public  async Task  LearnLesson(Guid idlesson ) 
        {
            var obj = _repository.FirstOrDefault(x => x.UserId == _currentUser.Id && x.LessonId == idlesson);
            if (obj != null)
            {
                try
                {
                    Guid userid = (Guid)this._currentUser.Id;


                    await _repository.InsertAsync(new LessonInfoOfUser
                    {
                        LessonId = idlesson,
                        UserId = userid,
                        Progress = 0
                    }, autoSave: true
                        );

                    List<Word> list = _wordrepository.Where(x => x.LessonId == idlesson).ToList();
                    if (list.Count() != 0)
                    {
                        foreach (Word w in list)
                        {
                            await _learnrepository.InsertAsync(
                                new Learn
                                {
                                    UserId = userid,
                                    WordId = w.Id,
                                    LessonId = idlesson,
                                    Level = 0,
                                    DateReview = DateTime.Now.AddHours(400),
                                    DateofLearn = DateTime.Now,
                                    Note = ""



                                }, autoSave: true);
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
        }
       

        
        //layra lesson tu khoa hoc cua toi 
        public  async Task<List<LessonInfoOfUserDto>> GetMyLessonList(Guid idcourse)
        {
            await CheckGetListPolicyAsync();

            Guid myid = (Guid)_currentUser.Id;
            var query = from ls in _repository
                        join lesson in _lesrepository on ls.LessonId equals lesson.Id
                        where lesson.CourseId == idcourse && ls.UserId == myid
                        select new { ls, lesson };

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var DTos = queryResult.Select(x =>
           {
               var dto = ObjectMapper.Map<LessonInfoOfUser, LessonInfoOfUserDto>(x.ls);
               dto.LessonName = x.lesson.Name;
               return dto;
           }).ToList();


            return new List<LessonInfoOfUserDto>(DTos);
        }

    }
}
