using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace BookStore.Aggregates.Book
{
    public class Price : ValueObject
    {
        private Price() { }
        public decimal Value { get; }
        public Price(decimal value) { Value = value; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
