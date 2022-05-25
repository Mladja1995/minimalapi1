using Diligent.MinimalAPI.Models;

namespace Diligent.MinimalAPI.Services
{
    public interface IProfesorService
    {
        Task<bool> CreateProfesor(Profesor profesor);
        Task<List<Profesor>> GetAllAsync();
        Task<Profesor> GetProfesorById(int id);
        Task<Profesor> GetProfesorByName(string firstName, string lastName);
        Task<bool> DeleteProfesorAsync(string firstName, string lastName);
        Task<bool> UpdateProfesorAsync(Profesor profesor);
    }
}
