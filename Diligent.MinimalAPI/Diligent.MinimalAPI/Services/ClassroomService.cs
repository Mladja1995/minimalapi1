using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Models;
using Diligent.MinimalAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Diligent.MinimalAPI.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly FacultyContext _facultyContext;

        public ClassroomService(FacultyContext facultyContext)
        {
            _facultyContext = facultyContext;
        }

        public async Task<bool> CreateAsync(Classroom classroom)
        {
            _facultyContext.Classrooms.Add(classroom);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(string identifier)
        {
            var existingClassroom = await GetByIdentifierAsync(identifier);
            if (existingClassroom is null)
            {
                return false;
            }

            _facultyContext.Remove(existingClassroom);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Classroom>> GetAllAsync()
        {
            return await _facultyContext.Classrooms.ToListAsync();
        }

        public async Task<Classroom> GetByIdentifierAsync(string identifier)
        {
            return await _facultyContext.Classrooms.Where(x => x.Identifier.Equals(identifier)).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Classroom classroom)
        {
            var existingIdentifier = await GetByIdentifierAsync(classroom.Identifier);
            if (existingIdentifier is null)
            {
                return false;
            }

            existingIdentifier.Section = classroom.Section;
            existingIdentifier.Identifier = classroom.Identifier;
            existingIdentifier.Floor = classroom.Floor;
            existingIdentifier.NumberOfSeats = classroom.NumberOfSeats;
            existingIdentifier.Type = classroom.Type;

            return await _facultyContext.SaveChangesAsync() > 0;
        }
    }
}
