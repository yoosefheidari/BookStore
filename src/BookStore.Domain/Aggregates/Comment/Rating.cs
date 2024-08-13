using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace BookStore.Aggregates.Comment
{
    public class Rating : ValueObject
    {
        private Rating() { }
        public Rating(byte rate) { Rate = rate; }
        public byte Rate { get; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Rate;
        }
    }
}
