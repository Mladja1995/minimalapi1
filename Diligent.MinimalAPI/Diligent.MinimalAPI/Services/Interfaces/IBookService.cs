using Diligent.MinimalAPI.Models;

namespace Diligent.MinimalAPI.Services
{
    public interface IBookService
    {
        Task<bool> CreateBook(Book project);
        Task<List<Book>> GetAllAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<bool> DeleteBookAsync(int id);
        Task<bool> UpdateBookAsync(Book project);
    }
}
