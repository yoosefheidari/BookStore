using BookStore.Aggregates.Book;
using BookStore.Data.Book;
using BookStore.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace BookStore.Services.Implementations
{
    public class BookRatingService : DomainService, IBookRatingService
    {
        private readonly IBookRepository _bookRepository;

        public BookRatingService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public double CalculateBookRating(List<byte> comments)
        {
            var ratings = comments.Average(x => x);
            return ratings;
        }

        public async Task<Book> GetBookById(int id)
        {
            var bookid = new BookId(id);
            return await _bookRepository.GetBookById(bookid);
        }
    }
}
