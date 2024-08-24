using Abp.Application.Services.Dto;
using BookStore.Aggregates.Book;
using BookStore.Contracts;
using BookStore.Data.Book;
using BookStore.Data.Comment;
using BookStore.Dtos;
using BookStore.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace BookStore.Implementations
{
    [RemoteService(IsEnabled = false)]
    public class BookAppService : ApplicationService, IBookAppService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IFileAppService _fileAppService;
        private readonly IDistributedCache<BookRatingCacheDto> _cacheService;

        public BookAppService(
            IBookRepository bookRepository
            , ICommentRepository commentRepository
            , IFileAppService fileAppService
            , IDistributedCache<BookRatingCacheDto> cacheService)
        {
            _bookRepository = bookRepository;
            LocalizationResource = typeof(BookStoreResource);
            _commentRepository = commentRepository;
            _fileAppService = fileAppService;
            _cacheService = cacheService;
        }

        public async Task AddBook(AddBookInputDto bookInfo)
        {
            var book = ObjectMapper.Map<AddBookInputDto, Book>(bookInfo);
            var bookId = await _bookRepository.AddBook(book);

            foreach (var image in bookInfo.Images)
            {
                var fileInfo = new SaveBlobInputDto { BookId = bookId, Image = image };
                var path = await _fileAppService.SaveBlobAsync(fileInfo);
                var coverInfo = new SaveCoverInputDto { BookId = bookId, Path = path };
                var cover = ObjectMapper.Map<SaveCoverInputDto, BookCover>(coverInfo);
                await _bookRepository.AddCover(cover);
            }
        }

        public async Task<PagedResultDto<BookOutputDto>> GetBooks(PagedResultRequestDto requestDto)
        {
            var books = await _bookRepository.GetBooks(requestDto.SkipCount, requestDto.MaxResultCount);

            if (books.Count == 0 || books is null) throw new BusinessException("no result found");

            var mappedResult = ObjectMapper.Map<List<Book>, List<BookOutputDto>>(books);

            foreach (var book in mappedResult)
            {
                book.Rating = Math.Round(book.Rating, 1);
                var covers = await _bookRepository.GetCovers(book.Id);
                foreach (var path in covers)
                {
                    var input = new GetBlobRequestDto() { Name = path };
                    var image = await _fileAppService.GetBlobAsync(input);
                    book.Covers.Add(image.Content);
                }
            }
            return new PagedResultDto<BookOutputDto>(mappedResult.Count, mappedResult);
        }
    }
}
