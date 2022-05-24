using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Models;
using Diligent.MinimalAPI.Services.Interfaces;

namespace Diligent.MinimalAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly FacultyContext _facultyContext;

        public CourseService(FacultyContext facultyContext)
        {
            _facultyContext = facultyContext;
        }

        public int CreateCourse(Course course)
        {
            _facultyContext.Courses.Add(course);
            _facultyContext.SaveChanges();
            return course.Id;
        }
    }
}
