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

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await _facultyContext.Projects.
                                    Where(x => x.Id == id).SingleOrDefaultAsync();

            if (project is not null)
                _facultyContext.Projects.Remove(project);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _facultyContext.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _facultyContext.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProjectAsync(Project project)
        {
            var updateProject = await GetProjectByIdAsync(project.Id);
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
