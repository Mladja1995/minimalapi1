using Diligent.MinimalAPI.Models;

namespace Diligent.MinimalAPI.Services
{
    public interface IProjectService
    {
        Task<bool> CreateProject(Project project);
        Task<List<Project>> GetAllAsync();
        Task<Project> GetProjectByNameAsync(string name);
        Task<bool> DeleteProjectAsync(string name);
        Task<bool> UpdateProjectAsync(Project project);
    }
}
