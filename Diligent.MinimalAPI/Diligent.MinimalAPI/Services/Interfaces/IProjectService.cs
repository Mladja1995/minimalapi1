using Diligent.MinimalAPI.Models;

namespace Diligent.MinimalAPI.Services
{
    public interface IProjectService
    {
        Task<bool> CreateProject(Project project);
        Task<List<Project>> GetAllAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<bool> DeleteProjectAsync(int id);
        Task<bool> UpdateProjectAsync(Project project);
    }
}
