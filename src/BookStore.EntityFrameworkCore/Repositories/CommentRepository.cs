using BookStore.Aggregates.Comment;
using BookStore.Data.Comment;
using BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace BookStore.Repositories
{
    public class CommentRepository : EfCoreRepository<BookStoreDbContext, BookStore.Aggregates.Comment.Comment, CommentId>, ICommentRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentTenant _currentTenant;
        public CommentRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider, IUnitOfWork unitOfWork, ICurrentTenant currentTenant) : base(dbContextProvider)
        {
            _currentTenant = currentTenant;
            _currentTenant.Change(new Guid("14FCFBF0-A85C-46EC-8940-5F587AAEC761"));
            _unitOfWork = unitOfWork;
        }

        public async Task AddComment(Comment comment)
        {
            await DbContext.Comments.AddAsync(comment);
        }

        public async Task<Comment> GetCommentById(int CommentId, CancellationToken cancellationToken)
        {
            var comments = await DbContext.Comments.ToListAsync();
            var comment = comments.Where(x => x.Id.Id == CommentId).FirstOrDefault();
            return comment;
        }

        public async Task<List<Comment>> GetComments()
        {
            return await DbContext.Comments.ToListAsync();
        }

        public async Task<List<Comment>> GetCommentsByBookId(int bookId)
        {
            var comments = await DbContext.Comments.AsNoTracking().Where(x => x.BookId == bookId).ToListAsync();
            return comments;
        }
    }
}
