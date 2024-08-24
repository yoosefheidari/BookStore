using BookStore.Aggregates.Comment;
using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace BookStore.Specifications
{
    public class GetCommentByBookIdSpecification : Specification<Comment>
    {
        public int BookId { get; }
        public GetCommentByBookIdSpecification(int bookId)
        {
            BookId = bookId;
        }
        public override Expression<Func<Comment, bool>> ToExpression()
        {
            return x => x.BookId == BookId;
        }
    }
}
