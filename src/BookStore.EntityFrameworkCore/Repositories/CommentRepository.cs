using BookStore.Data.Comment;
using BookStore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class CommentRepository : EfCoreRepository<BookStoreDbContext, BookStore.Aggregates.Comment.Comment, int>, ICommentRepository
    {
        public CommentRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public Task AddComment(Aggregates.Comment.Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task AddDislike(int CommentId)
        {
            throw new NotImplementedException();
        }

        public Task AddLike(int CommentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Aggregates.Comment.Comment>> GetComments()
        {
            throw new NotImplementedException();
        }
    }
}
