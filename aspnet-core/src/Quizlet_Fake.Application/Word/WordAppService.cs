﻿
using System;

using Volo.Abp.Users;

using Volo.Abp.DependencyInjection;

using Quizlet_Fake.Courses;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Quizlet_Fake.Lessons;
using System.Threading.Tasks;
using System.Linq;
using Quizlet_Fake.Participations;
using System.Collections.Generic;
using Quizlet_Fake.Permissions;

namespace Quizlet_Fake.Words
{
    public class WordAppService :
         CrudAppService<
             Word,//Defines CRUD methods
             WordDto, //Used to show 
             Guid, //Primary key of the  entity
             PagedAndSortedResultRequestDto, //Used for paging/sorting
             WordCreateOrUpdateDto>, //Used to create/update 
         IWordAppService, ITransientDependency
    {
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<Word, Guid> _repository;
        private readonly IRepository<ParticipationPermission, Guid> perRepository;
        private readonly IRepository<Lesson, Guid> lessonsRepo;
        private readonly IRepository<Course, Guid> _courserepo;
        public WordAppService(IRepository<Word, Guid> repository, ICurrentUser currentUser, IRepository<ParticipationPermission, Guid> xrepo, IRepository<Lesson,Guid> yrepo,
            IRepository<Course, Guid> zrepo) : base(repository)
        {
            this._currentUser = currentUser;
            this._repository = repository;
            this.perRepository = xrepo;
            this.lessonsRepo = yrepo;


            this._courserepo = zrepo;

           
            GetListPolicyName = Quizlet_FakePermissions.Word.Default;

        }

        public override Task<WordDto> CreateAsync(WordCreateOrUpdateDto input)
        {
            var lession = lessonsRepo.FirstOrDefault(x => x.Id == input.LessonId);

            var cour = _courserepo.FirstOrDefault(x => x.Id == lession.CourseId);
            // var per = perRepository.FirstOrDefault(x => x.CourseId == lession.CourseId);

            //if (per != null)
            //{

            if (lession.CreatorId == _currentUser.Id)//per.UserId == _currentUser.Id)
                {
                   // Course cour = (Course)_courserepo.Where(x => x.Id == lession.CourseId);
                    cour.wordnumber += 1;
                   _courserepo.UpdateAsync(cour);
                    lession.wordnumber += 1;
                    lessonsRepo.UpdateAsync(lession);

                    return base.CreateAsync(input);
                }
           // }

           /* var per = perRepository.Where(x => x.CourseId == lession.CourseId).Where(x => x.UserId == _currentUser.Id).FirstOrDefault();

            if (per != null)
            {
                    return base.CreateAsync(input);
                
            }
           */
            
            return base.CreateAsync(new WordCreateOrUpdateDto());
        }

        public List<Word> GetWordOfLession(Guid id)
        {
            var word = new List<Word>();
            Guid currentId = (Guid)_currentUser.Id;
            var lession = lessonsRepo.FirstOrDefault(x => x.Id == id);
            var per = perRepository.Where(x => x.CourseId == lession.CourseId).Where(x => x.UserId == currentId).FirstOrDefault();
            if (per != null)
            {
                word = _repository.Where(x => x.LessonId == id).ToList();
                return word;
            }


            return word;
        }
        public override Task DeleteAsync(Guid id)
        {

            var word = _repository.FirstOrDefault(x => x.Id == id);
            var lession = lessonsRepo.FirstOrDefault(x => x.Id == word.LessonId);
            var per = perRepository.Where(x => x.CourseId == lession.CourseId).Where(x => x.UserId == _currentUser.Id).FirstOrDefault();
            if (per != null)
            {
                if (per.UserId == _currentUser.Id)
                {
                    return base.DeleteAsync(id);
                }
            }
            return base.DeleteAsync(new Guid());

        }

        public override Task<WordDto> GetAsync(Guid id)
        {
            var word = _repository.FirstOrDefault(x => x.Id == id);
            var lesson = lessonsRepo.FirstOrDefault(x => x.Id == word.LessonId);
            var per = perRepository.Where(x => x.CourseId == lesson.CourseId).Where(x => x.UserId == _currentUser.Id).FirstOrDefault();
            if (per != null)
            {
                return base.GetAsync(id);
            }
            return base.GetAsync(new Guid());
        }

        public override Task<WordDto> UpdateAsync(Guid id, WordCreateOrUpdateDto input)
        {


            var word = _repository.FirstOrDefault(x => x.Id == id);
            var lession = lessonsRepo.FirstOrDefault(x => x.Id == word.LessonId);
            var per = perRepository.FirstOrDefault(x => x.CourseId == lession.CourseId);

            if (per != null)
            {

                if (per.UserId == _currentUser.Id)
                {
                    return  base.UpdateAsync(id, input);
                }
            }
            return base.UpdateAsync(new Guid(), input);
        }


    }
}
