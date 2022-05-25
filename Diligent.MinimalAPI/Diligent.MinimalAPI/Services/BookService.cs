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


        public async Task<bool> DeleteBookAsync(string title)
        {
            var book = await _facultyContext.Books.
                                    Where(x => x.Title == title).SingleOrDefaultAsync();

            if (book is not null)
                _facultyContext.Books.Remove(book);
            return await _facultyContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _facultyContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByTitleAsync(string title)
        {
            return await _facultyContext.Books.Where(x => x.Title == title).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            var updateBook = await GetBookByTitleAsync(book.Title);
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
