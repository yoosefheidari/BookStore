using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace BookStore.Aggregates.Store
{
    public class Store : AggregateRoot<StoreId>, IMultiTenant
    {
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? TenantId { get; set; }

        public void SetCreationTime(DateTime creationTime)
        {
            CreatedAt = creationTime;
        }

        public void SetTenantId(Guid tenantId)
        {
            TenantId = tenantId;
        }
    }
}
