using BookStore.Aggregates.Book;
using BookStore.Data.Book;
using BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class BookRepository : EfCoreRepository<BookStoreDbContext, Aggregates.Book.Book, BookId>, IBookRepository
    {
        public BookRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<int> AddBook(Aggregates.Book.Book book)
        {
            await DbContext.Books.AddAsync(book);
            await DbContext.SaveChangesAsync();
            return book.Id.Id;
        }

        public async Task AddCover(BookCover cover)
        {
            await DbContext.bookCovers.AddAsync(cover);
        }

        public async Task<Book> GetBookById(BookId bookId)
        {
            return await DbContext.Books.Where(x => x.Id == bookId).FirstOrDefaultAsync();
        }

        public async Task<List<Aggregates.Book.Book>> GetBooks(int skipCount, int maxResultCount)
        {
            var y = CurrentTenant.Name;
            var result = await DbContext.Books.Skip((skipCount - 1) * maxResultCount).Take(maxResultCount).ToListAsync();
            return result;
        }

        public async Task<List<string>> GetCovers(int bookId)
        {
            var result = await DbContext.bookCovers.ToListAsync();
            return result.Where(x => x.BookId.Id == bookId).Select(p => p.Path).ToList();
        }

        public Task SetBookRating(int bookId, double rating)
        {
            throw new System.NotImplementedException();
        }
    }
}
