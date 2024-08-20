using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using NS = BookStore.Aggregates.Comment;

namespace BookStore.Data.Comment
{
    public interface ICommentRepository : IBasicRepository<NS.Comment, NS.CommentId>, IScopedDependency
    {
        Task<List<NS.Comment>> GetComments();
        Task<List<NS.Comment>> GetCommentsByBookId(int bookId);
        Task AddComment(NS.Comment comment);
        Task<NS.Comment> GetCommentById(int CommentId, CancellationToken cancellationToken);
    }
}
