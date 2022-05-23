using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Diligent.MinimalAPI.Services
{
   
    public class StudentService : IStudentService
    {
        private readonly FacultyContext _facultyContext;
        public StudentService(FacultyContext facultyContext)
        {
            _facultyContext = facultyContext;
        }
        async Task<List<Student>> IStudentService.GetAllAsync()
        {
            return await _facultyContext.Students.ToListAsync();
        }
    }
}
