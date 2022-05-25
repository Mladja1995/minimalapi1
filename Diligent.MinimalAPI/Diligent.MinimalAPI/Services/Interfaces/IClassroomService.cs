using Diligent.MinimalAPI.Models;

namespace Diligent.MinimalAPI.Services.Interfaces
{
    public interface IClassroomService
    {
        Task<bool> CreateAsync(Classroom classroom);
        Task<Classroom> GetByIdentifierAsync(string identifier);
        Task<List<Classroom>> GetAllAsync();
        Task<bool> UpdateAsync(Classroom classroom);
        Task<bool> DeleteAsync(string identifier);
    }
}
