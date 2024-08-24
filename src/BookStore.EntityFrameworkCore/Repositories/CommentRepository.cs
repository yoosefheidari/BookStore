using BookStore.Aggregates.Comment;
using BookStore.Data.Comment;
using BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class CommentRepository : EfCoreRepository<BookStoreDbContext, BookStore.Aggregates.Comment.Comment, CommentId>, ICommentRepository
    {
        public CommentRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task AddComment(Comment comment)
        {
            await DbContext.Comments.AddAsync(comment);
        }

        public async Task<Comment> GetCommentById(CommentId id, CancellationToken cancellationToken)
        {
            var comment = await DbContext.Comments.Where(x => x.Id == id).FirstOrDefaultAsync();
            return comment;
        }

        public async Task<List<Comment>> GetCommentsByBookId(int bookId)
        {
            var t = CurrentTenant.Name;
            var comments = await DbContext.Comments.Where(x => x.BookId == bookId).ToListAsync();
            return comments;
        }

        public async Task<List<byte>> GetCommentsRatingByBookId(int id)
        {
            return await DbContext.Comments.Where(x => x.BookId == id).Select(v => v.Rating.Value).ToListAsync();
        }
    }
}
