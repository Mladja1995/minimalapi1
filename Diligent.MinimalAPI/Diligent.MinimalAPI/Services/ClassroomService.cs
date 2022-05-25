using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Models;
using Diligent.MinimalAPI.Services.Interfaces;

namespace Diligent.MinimalAPI.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly FacultyContext _facultyContext;

        public ClassroomService(FacultyContext facultyContext)
        {
            _facultyContext = facultyContext;
        }

        public Task<bool> CreateAsync(Classroom classroom)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string identifier)
        {
            throw new NotImplementedException();
        }

        public Task<List<Classroom>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Classroom> GetByIdentifierAsync(string identifier)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Classroom classroom)
        {
            throw new NotImplementedException();
        }
    }
}
