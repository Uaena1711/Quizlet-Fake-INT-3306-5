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


        public override Task<LearnDto> CreateAsync(LearnCreateUpdateDto input)//dung khi xemlan dau 
            
        {
            input.Level = 0;
            input.DateofLearn = DateTime.Now;
            input.DateReview = DateTime.Now.AddHours(4000);
            
            return base.CreateAsync(input);
        }
        public async Task UpdateProgess(Guid LessonId)
        {
            try
            {
                var lernprogess = _lessonrepository.FirstOrDefault(x => x.UserId == _currentUser.Id && x.LessonId == LessonId);
                List<Learn> learns = _repository.Where(x => x.LessonId == LessonId && x.UserId == _currentUser.Id).ToList();
                int soluong = learns.Count();

                int sum = 0;
                foreach (Learn lean in learns)
                {
                    sum += lean.Level;
                }
                lernprogess.Progress = (int)sum * 100 / (5 * soluong);

                await _lessonrepository.UpdateAsync(lernprogess, autoSave: true);

                
               
            }
            catch ( Exception e)
            {
                
            }
        }

        public  async Task<LearnDto> UpdateLevelLearningWord( Guid idword, bool b)//dung khi kiem tra review
        {
            var wordinput = _repository.FirstOrDefault(x => x.Id == idword && x.UserId == _currentUser.Id);
            if( wordinput != null)
            {
                LearnCreateUpdateDto input = new LearnCreateUpdateDto();
                input = ObjectMapper.Map<Learn, LearnCreateUpdateDto>(wordinput);
                

                if( b)
                {
                    
                        input.Level = wordinput.Level + 1;
                        input.DateReview = DateTime.Now.AddHours(4 * input.Level);
                }
                else
                {
                    if (wordinput.Level > 1)
                    {
                        wordinput.Level -= 1;

                    }
                    input.DateReview = DateTime.Now.AddHours(4 * input.Level);
                }
                
                return await base.UpdateAsync(idword, input);
            }
            else
            {
                return await base.UpdateAsync(new Guid(), new LearnCreateUpdateDto() );
            }

        }

        

        public async Task<List<LearnDto>> GetMyWortdList(Guid learnid)
        {
            await CheckGetListPolicyAsync();

            Guid myid = (Guid)_currentUser.Id;
            var query = from word1 in _repository
                        join word in _word_rea_repository on word1.WordId equals word.Id
                        where word.LessonId == learnid && word1.UserId == myid
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

        public async Task<List<LearnDto>> GetMyReview(int from)
        {
            await CheckGetListPolicyAsync();

            Guid myid = (Guid)_currentUser.Id;

            var query = from word1 in _repository
                        join word in _word_rea_repository on word1.WordId equals word.Id
                        where DateTime.Compare(word1.DateReview,DateTime.Now) <= 0 && word1.UserId == myid
                        select new { word1, word };
            query = query.Skip(from).Take(20);
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


        public async Task<bool> TestResult(TestDto testDto)
        {
            Guid[] wordid =  testDto.words_list;
            bool[] result = testDto.isright;
            var l = new Learn();
            for( int i = 0; i < wordid.Length; i++)
            {
                 await UpdateLevelLearningWord(wordid[i], result[i]);
            }
            
           
            return true;
            
        }
        public async Task<List<LearnDto>> GetMyLessonTest(Guid LessonId, int from )
        {
            await CheckGetListPolicyAsync();

            Guid myid = (Guid)_currentUser.Id;

            var query = from word1 in _repository
                        join word in _word_rea_repository on word1.WordId equals word.Id
                        where word1.LessonId ==LessonId && word1.UserId == myid
                        select new { word1, word };
            query = query.Skip(from).Take(20);
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
