using Diligent.MinimalAPI.Database;
using Diligent.MinimalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Diligent.MinimalAPI.Services
{
    public class BookService : IBookService
    {
        private readonly FacultyContext _facultyContext;
        public BookService(FacultyContext facultyContext)
        {
            _facultyContext = facultyContext;
        }
        public async Task<bool> CreateBook(Book book)
        {
            await _facultyContext.Books.AddAsync(book);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _facultyContext.Books.
                                    Where(x => x.Id == id).SingleOrDefaultAsync();

            if (book is not null)
                _facultyContext.Books.Remove(book);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _facultyContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _facultyContext.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            var updateBook = await GetBookByIdAsync(book.Id);
            if (updateBook is null)
                return false;
            else
            {
                updateBook.PublishDate = book.PublishDate;
                updateBook.Author = book.Author;
                updateBook.ISBN = book.ISBN;
                updateBook.Description = book.Description; 
                updateBook.Title = book.Title;
                updateBook.PageNumber = book.PageNumber;

                return await _facultyContext.SaveChangesAsync() > 0;
            }
        }
    }
}
