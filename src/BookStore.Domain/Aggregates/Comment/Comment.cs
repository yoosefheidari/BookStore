using System;
using Volo.Abp;
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

        public void isValid(Comment comment)
        {
            if (string.IsNullOrWhiteSpace(comment.Description)) throw new BusinessException("Description must have value");
            if (Rating.Rate > 5 || Rating.Rate < 0) throw new BusinessException("Rate must be between 0 to 5");
        }
    }
}
