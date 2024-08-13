using BookStore.Aggregates.Book;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Data.Book
{
    public interface IBookRepository : IBasicRepository<BookStore.Aggregates.Book.Book, BookId>, IScopedDependency
    {
        Task<List<BookStore.Aggregates.Book.Book>> GetBooks();
        Task AddBook(BookStore.Aggregates.Book.Book book);
    }
}
