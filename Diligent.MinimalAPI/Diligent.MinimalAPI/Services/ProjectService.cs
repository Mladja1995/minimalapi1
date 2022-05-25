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

        public async Task<bool> CreateProject(Project project)
        {
            await _facultyContext.Projects.AddAsync(project);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProjectAsync(string name)
        {
            var project = await _facultyContext.Projects.
                                    Where(x => x.ProjectName == name).SingleOrDefaultAsync();

            if (project is not null)
                _facultyContext.Projects.Remove(project);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _facultyContext.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByNameAsync(string name)
        {
            return await _facultyContext.Projects.Where(x => x.ProjectName == name).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProjectAsync(Project project)
        {
            var updateProject = await GetProjectByNameAsync(project.ProjectName);
            if (updateProject is null)
                return false;
            else
            {
                updateProject.ProjectDescription = project.ProjectDescription;
                updateProject.ProjectName = project.ProjectName;
                updateProject.StartDate = project.StartDate;
                updateProject.EndDate = project.EndDate;
                updateProject.ProfesorId = project.ProfesorId;
                updateProject.StudentId = project.StudentId;    
                updateProject.CourseId = project.CourseId;
                updateProject.Technology = project.Technology;

                return await _facultyContext.SaveChangesAsync() > 0;
            }
        }
    }
}
