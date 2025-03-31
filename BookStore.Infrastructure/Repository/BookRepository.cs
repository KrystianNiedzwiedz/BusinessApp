using BookStore.Domain.Entities;
using BookStore.Domain.Repository;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _bookDbContext;

        public BookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }
        public async Task<Book> CreateAsync(Book book)
        {
            await _bookDbContext.Books.AddAsync(book);
            await _bookDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _bookDbContext.Books
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _bookDbContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookDbContext.Books.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Book book)
        {
            return await _bookDbContext.Books
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, book.Id)
                    .SetProperty(m => m.Name, book.Name)
                    .SetProperty(m => m.Description, book.Description)
                    .SetProperty(m => m.Author, book.Author)                   
                  );
        }
    }
}
