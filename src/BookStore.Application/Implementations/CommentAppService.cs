using BookStore.Aggregates.Comment;
using BookStore.Contracts;
using BookStore.Data.Comment;
using BookStore.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace BookStore.Implementations
{
    [RemoteService(IsEnabled = false)]
    public class CommentAppService : ApplicationService, ICommentAppService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IDistributedCache<BookRatingCacheDto> _cacheService;

        public CommentAppService(ICommentRepository commentRepository, IDistributedCache<BookRatingCacheDto> cacheService)
        {
            _commentRepository = commentRepository;
            _cacheService = cacheService;
        }

        public async Task AddComment(AddCommentInputDto commentInfo)
        {
            var comment = ObjectMapper.Map<AddCommentInputDto, Comment>(commentInfo);
            await _commentRepository.AddComment(comment);
            _cacheService.Set(commentInfo.BookId.ToString(), null);
        }

        public async Task AddDislike(LikeInputDto likeInfo)
        {
            var comment = await _commentRepository.GetCommentById(likeInfo.CommentId, default);
            comment.DislikeCount++;
            // await _commentRepository.AddLike(comment);
        }

        public async Task AddLike(LikeInputDto likeInfo)
        {
            var comment = await _commentRepository.GetCommentById(likeInfo.CommentId, default);
            comment.LikeCount++;
        }

        public async Task<List<CommentOutputDto>> GetComments()
        {
            var comments = await _commentRepository.GetComments();
            var result = ObjectMapper.Map<List<Comment>, List<CommentOutputDto>>(comments);
            return result;
        }
    }
}
