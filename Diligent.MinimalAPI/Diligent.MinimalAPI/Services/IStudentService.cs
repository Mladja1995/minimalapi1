using Diligent.MinimalAPI.Models;

namespace Diligent.MinimalAPI.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync();
    }
}
