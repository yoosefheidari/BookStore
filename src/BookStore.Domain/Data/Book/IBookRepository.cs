using BookStore.Aggregates.Book;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using BAB = BookStore.Aggregates.Book;

namespace BookStore.Data.Book
{
    public interface IBookRepository : IBasicRepository<BAB.Book, BAB.BookId>, IScopedDependency
    {
        Task<List<BAB.Book>> GetBooks(int skipCount, int maxResultCount);
        Task<int> AddBook(BAB.Book book);
        Task AddCover(BAB.BookCover cover);
        Task<List<string>> GetCovers(int bookId);
        Task<BAB.Book> GetBookById(BookId bookId);
        Task SetBookRating(int bookId, double rating);
    }
}
