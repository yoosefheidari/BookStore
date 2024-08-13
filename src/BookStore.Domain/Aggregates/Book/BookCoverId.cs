using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace BookStore.Aggregates.Book
{
    public class BookCoverId : ValueObject
    {
        public int Id { get; }

        public BookCoverId(int value)
        {
            Id = value;
        }
        private BookCoverId()
        {

        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
        }
    }
}
