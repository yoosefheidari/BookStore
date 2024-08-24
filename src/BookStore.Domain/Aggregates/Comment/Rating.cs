using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace BookStore.Aggregates.Comment
{
    public class Rating : ValueObject
    {
        private Rating() { }
        public Rating(byte rate) { Value = rate; }
        public byte Value { get; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
