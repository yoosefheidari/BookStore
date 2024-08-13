using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BookStore.Aggregates.Store
{
    public class Store : FullAuditedAggregateRoot<int>, IMultiTenant
    {
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? TenantId { get; set; }
    }
}
