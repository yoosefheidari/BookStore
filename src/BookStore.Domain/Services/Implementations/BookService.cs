using BookStore.Aggregates.Comment;
using BookStore.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Services;

namespace BookStore.Services.Implementations
{
    public class BookService : DomainService, IBookRating
    {
        public double GetBookRating(List<Comment> comments)
        {
            var ratings = comments.Average(x => x.Rating.Rate);
            return ratings;
        }
    }
}
