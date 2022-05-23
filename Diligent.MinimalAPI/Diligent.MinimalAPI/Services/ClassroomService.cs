using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Services.Interfaces;

namespace Diligent.MinimalAPI.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly FacultyContext _facultyContext;

        public ClassroomService(FacultyContext facultyContext)
        {
            _facultyContext = facultyContext;
        }
    }
}
