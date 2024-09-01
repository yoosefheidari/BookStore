using BookStore.Aggregates.Book;
using BookStore.Aggregates.Comment;
using BookStore.Contracts;
using BookStore.Data.Comment;
using BookStore.Dtos;
using BookStore.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Domain.ChangeTracking;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Implementations
{
    [RemoteService(IsEnabled = false)]
    public class CommentAppService : ApplicationService, ICommentAppService
    {
        private readonly IDistributedCache<BookRatingCacheDto> _cacheService;
        private readonly IBookRatingService _bookRatingService;
        private readonly IRepository<Book, BookId> _bookRepository;
        private readonly IRepository<Comment, CommentId> _commentRepository;
        private readonly ICommentRepository _customCommentRepository;

        public CommentAppService(IRepository<Comment, CommentId> commentRepository,
            IDistributedCache<BookRatingCacheDto> cacheService,
            IBookRatingService bookRatingService,
            IRepository<Book, BookId> bookRepository,
            ICommentRepository customCommentRepository)
        {
            _commentRepository = commentRepository;
            _cacheService = cacheService;
            _bookRatingService = bookRatingService;
            _bookRepository = bookRepository;
            _customCommentRepository = customCommentRepository;
        }

        public async Task AddComment(AddCommentInputDto commentInfo)
        {
            var comment = ObjectMapper.Map<AddCommentInputDto, Comment>(commentInfo);
            await _commentRepository.InsertAsync(comment);
            var commentsRating = await _customCommentRepository.GetCommentsRatingByBookId(commentInfo.BookId);
            commentsRating.Add(commentInfo.Rating);
            var rating = _bookRatingService.CalculateBookRating(commentsRating);
            var bookId = ObjectMapper.Map<int, BookId>(commentInfo.BookId);
            var book = await _bookRepository.GetAsync(bookId);
            book.SetRating(rating);
        }

        public async Task AddDislike(LikeInputDto likeInfo)
        {
            var commentId = ObjectMapper.Map<int, CommentId>(likeInfo.CommentId);
            var comment = await _commentRepository.GetAsync(commentId);
            comment.DislikeCount++;
        }

        public async Task AddLike(LikeInputDto likeInfo)
        {

            var commentId = ObjectMapper.Map<int, CommentId>(likeInfo.CommentId);
            var comment = await _commentRepository.GetAsync(commentId);
            comment.LikeCount++;
        }

        [DisableEntityChangeTracking]
        public async Task<List<CommentOutputDto>> GetComments(int bookId)
        {
            using (_commentRepository.DisableTracking())
            {
                var comments = await _commentRepository.GetListAsync(x => x.BookId == bookId);
                var result = ObjectMapper.Map<List<Comment>, List<CommentOutputDto>>(comments);
                return result;
            }

        }
    }
}
