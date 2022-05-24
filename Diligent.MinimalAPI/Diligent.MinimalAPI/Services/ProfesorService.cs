using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Diligent.MinimalAPI.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly FacultyContext _facultyContext;
        public ProfesorService(FacultyContext facultyContext)
        {
            _facultyContext = facultyContext;
        }

        public async Task<bool> CreateProfesor(Profesor profesor)
        {
            await _facultyContext.Profesors.AddAsync(profesor);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProfesorAsync(int id)
        {
            var profesor = await _facultyContext.Profesors.
                                  Where(x => x.Id == id).SingleOrDefaultAsync();

            if (profesor is not null)
                _facultyContext.Profesors.Remove(profesor);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Profesor>> GetAllAsync()
        {
            return await _facultyContext.Profesors.ToListAsync();
        }

        public async Task<Profesor> GetProfesorByName(string firstName, string lastName)
        {
            return await _facultyContext.Profesors.
                        Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefaultAsync();
        }

        public async Task<Profesor> GetProfesorById(int id)
        {
            return await _facultyContext.Profesors.
                        Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProfesorAsync(Profesor profesor)
        {
            var updateProfesor = await GetProfesorById(profesor.Id);
            if (updateProfesor is null)
                return false;
            else 
            {
                updateProfesor.FirstName = profesor.FirstName;
                updateProfesor.LastName = profesor.LastName;
                updateProfesor.CourseId = profesor.CourseId;
                updateProfesor.BookId = profesor.BookId;
                
                return await _facultyContext.SaveChangesAsync() > 0;
            }

        }
    }
}
