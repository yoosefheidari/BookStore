using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace BookStore.Aggregates.Store
{
    public class StoreId : ValueObject
    {
        public int Id { get; private set; }

        public StoreId(int value)
        {
            Id = value;
        }

        private StoreId()
        {

        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
        }
    }
}
