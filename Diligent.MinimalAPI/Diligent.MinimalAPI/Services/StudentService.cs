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

        public async Task<bool> CreateStudentAsync(Student student)
        {
            await _facultyContext.Students.AddAsync(student);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStudentAsync(Student student, int id)
        {
            var studentDb = await _facultyContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(studentDb == null) { return false; }
            studentDb.FirstName = student.FirstName;
            studentDb.LastName = student.LastName;
            studentDb.IndexNum = student.IndexNum;
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        async Task<List<Student>> IStudentService.GetAllAsync()
        {
            return await _facultyContext.Students.ToListAsync();
        }

        async Task<Student> IStudentService.GetByIdAsync(int id)
        {
            return await _facultyContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
