using Volo.Abp.Domain.Entities;

namespace BookStore.Aggregates.Book
{
    public class BookCover : Entity<BookCoverId>
    {
        public string Path { get; set; }
        public BookId BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
