using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace BookStore.Aggregates.Book
{
    public class BookId : ValueObject
    {
        public int Id { get; }

        public BookId(int value)
        {
            Id = value;
        }
        private BookId()
        {

        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
        }
    }
}
