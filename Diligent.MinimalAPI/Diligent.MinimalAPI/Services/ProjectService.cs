using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Diligent.MinimalAPI.Services
{
    public class ProjectService : IProjectService
    {
        private readonly FacultyContext _facultyContext;
        public ProjectService(FacultyContext facultyContext)
        {
            _facultyContext = facultyContext;
        }

        async Task<Project> GetProjectByName(string projectName)
        {
            return await _facultyContext.Projects.Where(p => p.ProjectName == projectName).FirstOrDefaultAsync();
                
        }
        async Task<List<Project>> GetAllAsync()
        {
            return await _facultyContext.Projects.ToListAsync();
        }


        Task<bool> IProjectService.CreateProject(Project project)
        {
            throw new NotImplementedException();
        }

        Task<List<Project>> IProjectService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
