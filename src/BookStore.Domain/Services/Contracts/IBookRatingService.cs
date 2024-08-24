using BookStore.Aggregates.Book;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;

namespace BookStore.Services.Contracts
{
    public interface IBookRatingService : IDomainService, IScopedDependency
    {
        double CalculateBookRating(List<byte> commentsRating);
        Task<Book> GetBookById(int id);
    }
}
