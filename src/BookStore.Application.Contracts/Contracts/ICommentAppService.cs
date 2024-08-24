using BookStore.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace BookStore.Contracts
{
    public interface ICommentAppService : IApplicationService, IScopedDependency
    {
        Task AddComment(AddCommentInputDto commentInfo);
        Task<List<CommentOutputDto>> GetComments(int bookId);
        Task AddLike(LikeInputDto likeInfo);
        Task AddDislike(LikeInputDto likeInfo);
    }
}
