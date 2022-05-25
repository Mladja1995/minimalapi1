using Diligent.MinimalAPI.Models;

namespace Diligent.MinimalAPI.Services.Interfaces
{
    public interface ICourseService
    {
        Task<bool> CreateAsync(Course course);
        Task<Course> GetByCodeAsync(string code);
        Task<List<Course>> GetAllAsync();
        Task<bool> UpdateAsync(Course course);
        Task<bool> DeleteAsync(string code);
    }
}
