using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BookStore.Aggregates.Book
{
    public class Book : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public string Title { get; private set; }
        public Price Price { get; private set; }
        public string Author { get; private set; }
        public DateTime PublishDate { get; private set; }
        public Guid? TenantId { get; private set; }
        public int StoreId { get; private set; }
    }
}
