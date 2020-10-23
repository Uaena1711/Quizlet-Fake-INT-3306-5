using AutoMapper;
using Quizlet_Fake.Courses;
using Quizlet_Fake.LogCoursesPermission;
using Quizlet_Fake.Participations;

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
        }
    }
}
