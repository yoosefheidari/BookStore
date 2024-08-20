using BookStore.Aggregates.Book;
using BookStore.Contracts;
using BookStore.Data.Book;
using BookStore.Data.Comment;
using BookStore.Dtos;
using BookStore.Localization;
using BookStore.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;

namespace BookStore.Implementations
{
    [RemoteService(IsEnabled = false)]
    public class BookAppService : ApplicationService, IBookAppService, IScopedDependency
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IBookRating _bookService;
        private readonly IFileAppService _fileAppService;
        private readonly IDistributedCache<BookRatingCacheDto> _cacheService;

        public BookAppService(IBookRepository bookRepository
            , IBookRating bookService, ICommentRepository commentRepository
            , IFileAppService fileAppService
            , IDistributedCache<BookRatingCacheDto> cacheService)
        {
            _bookRepository = bookRepository;
            LocalizationResource = typeof(BookStoreResource);
            _bookService = bookService;
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

        public async Task<List<BookOutputDto>> GetBooks()
        {
            var books = await _bookRepository.GetBooks();

            var mappedResult = ObjectMapper.Map<List<Book>, List<BookOutputDto>>(books);

            foreach (var book in mappedResult)
            {
                var cache = _cacheService.Get(book.Id.ToString());
                if (cache != null)
                    book.Rating = cache.Rating;
                else
                {
                    var comments = await _commentRepository.GetCommentsByBookId(book.Id);
                    if (comments != null && comments.Count > 0)
                    {

                        var rating = _bookService.GetBookRating(comments);

                        book.Rating = rating;
                        var bookRating = new BookRatingCacheDto() { Rating = rating };
                        _cacheService.Set(book.Id.ToString(), bookRating);
                    }
                }

                var covers = await _bookRepository.GetCovers(book.Id);
                foreach (var path in covers)
                {
                    var input = new GetBlobRequestDto() { Name = path };
                    var image = await _fileAppService.GetBlobAsync(input);
                    book.Covers.Add(image.Content);
                }


            }
            return mappedResult;
        }
    }
}
