using Diligent.MinimalAPI.Models;

namespace Diligent.MinimalAPI.Services
{
    public interface IProjectService
    {
        public Task<bool> CreateProject(Project project);
        public Task<List<Project>> GetAllAsync();
        public Task<Project> GetProjectById(int id);
        public Task<bool> DeleteProject(int id);
        public Task<Project> UpdateProject(Project project);
    }
}
