using Diligent.MinimalAPI.Database;
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
    }
}
