using BookStore.Aggregates.Comment;
using BookStore.Contracts;
using BookStore.Data.Comment;
using BookStore.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace BookStore.Implementations
{
    [RemoteService(IsEnabled = false)]
    public class CommentAppService : ApplicationService, ICommentAppService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentAppService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task AddComment(AddCommentInputDto commentInfo)
        {
            var comment = ObjectMapper.Map<AddCommentInputDto, Comment>(commentInfo);
            await _commentRepository.AddComment(comment);
        }

        public async Task AddDislike(LikeInputDto likeInfo)
        {
            await _commentRepository.AddDislike(likeInfo.CommentId);
        }

        public async Task AddLike(LikeInputDto likeInfo)
        {
            await _commentRepository.AddLike(likeInfo.CommentId);
        }

        public async Task<List<CommentOutputDto>> GetComments()
        {
            var comments = await _commentRepository.GetComments();
            var result = ObjectMapper.Map<List<Comment>, List<CommentOutputDto>>(comments);
            return result;
        }
    }
}
