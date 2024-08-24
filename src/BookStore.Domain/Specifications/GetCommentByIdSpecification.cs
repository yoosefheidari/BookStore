using BookStore.Aggregates.Comment;
using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace BookStore.Specifications
{
    public class GetCommentByIdSpecification : Specification<Comment>
    {
        public int Id { get; }
        public GetCommentByIdSpecification(int id)
        {
            Id = id;
        }
        public override Expression<Func<Comment, bool>> ToExpression()
        {
            return x => x.Id.Id == Id;
        }
    }
}
