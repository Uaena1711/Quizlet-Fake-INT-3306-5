using AutoMapper;
using Quizlet_Fake.Courses;
using Quizlet_Fake.Lessons;
using Quizlet_Fake.Lesssion;
using Quizlet_Fake.LogCoursesPermission;
using Quizlet_Fake.Participations;
using Quizlet_Fake.Words;

namespace Quizlet_Fake
{
    public class Quizlet_FakeApplicationAutoMapperProfile : Profile
    {
        public Quizlet_FakeApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Course, CourseDto>();
            CreateMap<CourseCreateUpdateDto, Course>();
            CreateMap<ParticipationPermission, CoursesPermissionDto>();
            CreateMap<CoursesPermissionCreateUpdateDto, ParticipationPermission>();
            CreateMap<CourseCreateUpdateDto, CoursesPermissionDto>();
            CreateMap<LessionCreateorUpdateDto, Lesson>();
            CreateMap<Lesson, LessionDto>();
            CreateMap<Word, WordDto>();
            CreateMap<WordCreateOrUpdateDto, Word>();
        }
    }
}
