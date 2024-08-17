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
using Volo.Abp.DependencyInjection;

namespace BookStore.Implementations
{
    [RemoteService(IsEnabled = false)]
    public class BookAppService : ApplicationService, IBookAppService, IScopedDependency
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IBookService _bookService;

        public BookAppService(IBookRepository bookRepository, IBookService bookService, ICommentRepository commentRepository)
        {
            _bookRepository = bookRepository;
            LocalizationResource = typeof(BookStoreResource);
            _bookService = bookService;
            _commentRepository = commentRepository;
        }

        public async Task AddBook(AddBookInputDto bookInfo)
        {
            var book = ObjectMapper.Map<AddBookInputDto, Book>(bookInfo);
            await _bookRepository.AddBook(book);
        }

        public async Task<List<BookOutputDto>> GetBooks()
        {
            var books = await _bookRepository.GetBooks();

            var mappedResult = ObjectMapper.Map<List<Book>, List<BookOutputDto>>(books);

            foreach (var book in mappedResult)
            {
                var comments = await _commentRepository.GetCommentsByBookId(book.Id);
                if (comments != null && comments.Count > 0)
                {
                    var rating = _bookService.GetBookRating(comments);
                    book.Rating = rating;
                }

            }

            return mappedResult;
        }


    }
}
