using Diligent.MinimalAPI.Models;

namespace Diligent.MinimalAPI.Services
{
    public interface IBookService
    {
        Task<bool> CreateBook(Book book);
        Task<List<Book>> GetAllAsync();
        Task<Book> GetBookByTitleAsync(string title);
        Task<bool> DeleteBookAsync(string title);
        Task<bool> UpdateBookAsync(Book book);
    }
}
