using BookStore.Aggregates.Comment;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Data.Comment
{
    public interface ICommentRepository : IBasicRepository<BookStore.Aggregates.Comment.Comment, CommentId>, IScopedDependency
    {
        Task<List<BookStore.Aggregates.Comment.Comment>> GetComments();
        Task AddComment(BookStore.Aggregates.Comment.Comment comment);
        Task AddLike(int CommentId);
        Task AddDislike(int CommentId);
    }
}
