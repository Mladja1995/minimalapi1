using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Models;
using Diligent.MinimalAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Diligent.MinimalAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly FacultyContext _facultyContext;

        public CourseService(FacultyContext facultyContext)
        {
            _facultyContext = facultyContext;
        }

        public async Task<bool> CreateAsync(Course course)
        {
            _facultyContext.Courses.Add(course);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(string code)
        {
            var existingCourse = await GetByCodeAsync(code);
            if (existingCourse is null)
            {
                return false;
            }

            _facultyContext.Remove(existingCourse);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _facultyContext.Courses.ToListAsync();
        }

        public async Task<Course> GetByCodeAsync(string code)
        {
            return await _facultyContext.Courses.Where(x => x.Code.Equals(code)).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            var existingCourse = await GetByCodeAsync(course.Code);
            if (existingCourse is null)
            {
                return false;
            }

            existingCourse.Code = course.Code; 
            existingCourse.CreatedDate = course.CreatedDate;
            existingCourse.ProfesorId = course.ProfesorId;
            existingCourse.Description= course.Description;
            existingCourse.Semestar = course.Semestar;
            existingCourse.Title = course.Title;

            return await _facultyContext.SaveChangesAsync() > 0;
        }
    }
}
