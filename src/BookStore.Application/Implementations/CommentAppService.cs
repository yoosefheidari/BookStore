﻿using BookStore.Aggregates.Book;
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
using Volo.Abp.Domain.Repositories;

namespace BookStore.Implementations
{
    [RemoteService(IsEnabled = false)]
    public class CommentAppService : ApplicationService, ICommentAppService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IDistributedCache<BookRatingCacheDto> _cacheService;
        private readonly IBookRatingService _bookRatingService;
        private readonly IRepository<Book, BookId> _bookRepository;

        public CommentAppService(ICommentRepository commentRepository,
            IDistributedCache<BookRatingCacheDto> cacheService,
            IBookRatingService bookRatingService,
            IRepository<Book, BookId> bookRepository)
        {
            _commentRepository = commentRepository;
            _cacheService = cacheService;
            _bookRatingService = bookRatingService;
            _bookRepository = bookRepository;
        }

        public async Task AddComment(AddCommentInputDto commentInfo)
        {
            var comment = ObjectMapper.Map<AddCommentInputDto, Comment>(commentInfo);
            await _commentRepository.AddComment(comment);
            var commentsRating = await _commentRepository.GetCommentsRatingByBookId(commentInfo.BookId);
            commentsRating.Add(commentInfo.Rating);
            var rating = _bookRatingService.CalculateBookRating(commentsRating);
            var bookId = ObjectMapper.Map<int, BookId>(commentInfo.BookId);
            var book = await _bookRepository.GetAsync(bookId);
            book.SetRating(rating);
        }

        public async Task AddDislike(LikeInputDto likeInfo)
        {
            var commentId = ObjectMapper.Map<int, CommentId>(likeInfo.CommentId);
            var comment = await _commentRepository.GetCommentById(commentId, default);
            comment.DislikeCount++;
        }

        public async Task AddLike(LikeInputDto likeInfo)
        {

            var commentId = ObjectMapper.Map<int, CommentId>(likeInfo.CommentId);
            var comment = await _commentRepository.GetCommentById(commentId, default);
            comment.LikeCount++;
        }

        public async Task<List<CommentOutputDto>> GetComments(int bookId)
        {
            var comments = await _commentRepository.GetCommentsByBookId(bookId);
            var result = ObjectMapper.Map<List<Comment>, List<CommentOutputDto>>(comments);
            return result;
        }
    }
}
