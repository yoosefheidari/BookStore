using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BookStore.Aggregates.Comment
{
    public class Comment : FullAuditedAggregateRoot<CommentId>, IMultiTenant
    {
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Rating Rating { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int BookId { get; set; }
        public Guid? TenantId { get; set; }
    }
}
