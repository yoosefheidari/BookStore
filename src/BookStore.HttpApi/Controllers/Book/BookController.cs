using BookStore.Contracts;
using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Controllers.Book
{
    [ApiController]
    public class BookController : BookStoreController
    {
        private readonly IBookAppService _bookAppService;

        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookAppService.GetBooks());
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(AddBookInputDto addBook, CancellationToken cancellationToken)
        {
            await _bookAppService.AddBook(addBook);
            return Ok();
        }

    }
}
