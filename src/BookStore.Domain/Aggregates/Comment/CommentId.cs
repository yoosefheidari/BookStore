using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace BookStore.Aggregates.Comment
{
    public class CommentId : ValueObject
    {
        public int Id { get; }

        public CommentId(int value)
        {
            Id = value;
        }
        private CommentId()
        {
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
        }
    }
}
