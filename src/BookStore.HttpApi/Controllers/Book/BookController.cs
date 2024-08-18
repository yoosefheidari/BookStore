using BookStore.Contracts;
using BookStore.Dtos;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Controllers.Book
{
    [ApiController]
    [Route("Books")]
    public class BookController : BookStoreController
    {
        private readonly IBookAppService _bookAppService;

        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetBooks()
        {
            var str = L["Home"];
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture;
            return Ok(await _bookAppService.GetBooks());
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddBook(AddBookInputDto addBook, CancellationToken cancellationToken)
        {
            await _bookAppService.AddBook(addBook);
            return Ok();
        }

    }
}
