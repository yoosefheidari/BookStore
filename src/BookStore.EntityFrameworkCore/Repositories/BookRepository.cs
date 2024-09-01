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
    public class BookRepository : EfCoreRepository<BookStoreDbContext, Book, BookId>, IBookRepository
    {
        public BookRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<int> AddBook(Book book)
        {

            await DbContext.Books.AddAsync(book);
            await DbContext.SaveChangesAsync();
            return book.Id.Id;
        }

        public async Task AddCover(BookCover cover)
        {
            await DbContext.BookCovers.AddAsync(cover);
        }

        public async Task<Book> GetBookById(BookId bookId) => await (await GetDbContextAsync()).Books.FindAsync(bookId);

        public async Task<List<Book>> GetBooks(int skipCount, int maxResultCount)
        {
            var result = await DbContext.Books.AsNoTracking()
                .Skip(skipCount)
                .Take(maxResultCount).ToListAsync();
            //return result;

            var dbContext = await GetDbContextAsync();
            var query = dbContext.Books
            .Where(f => f.rating == 2);

            await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Forms WHERE IsDraft = 1"); //Execute Raw SQL Query


            return await query.ToListAsync();
        }

        public async Task<List<string>> GetCovers(int bookId)
        {
            var result = await DbContext.BookCovers.ToListAsync();
            return result.Where(x => x.BookId.Id == bookId).Select(p => p.Path).ToList();
        }

        public Task SetBookRating(int bookId, double rating)
        {
            throw new System.NotImplementedException();
        }
    }
}
