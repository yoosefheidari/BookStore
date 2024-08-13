using BookStore.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace BookStore.Contracts
{
    public interface IBookAppService : IApplicationService, IScopedDependency
    {
        Task AddBook(AddBookInputDto bookInfo);
        Task AddComment(AddCommentInputDto commentInfo);
        Task AddLike(LikeInputDto likeInfo);
        Task AddDislike(LikeInputDto likeInfo);
        Task<List<BookOutputDto>> GetStoreBooks();
        Task<List<StoreOutputDto>> GetStores();
        Task<List<CommentOutputDto>> GetComments();
    }
}
