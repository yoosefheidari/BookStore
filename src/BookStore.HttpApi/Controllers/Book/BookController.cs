using Abp.Application.Services.Dto;
using BookStore.Contracts;
using BookStore.Dtos;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;

namespace BookStore.Controllers.Book
{
    [ApiController]
    [Route("Books")]
    public class BookController : BookStoreController
    {
        private readonly IBookAppService _bookAppService;
        private readonly ICurrentTenant currentTenant;

        public BookController(IBookAppService bookAppService, ICurrentTenant currentTenant)
        {
            _bookAppService = bookAppService;
            this.currentTenant = currentTenant;
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> GetBooks(PagedResultRequestDto requestDto)
        {
            var c = currentTenant;
            var str = L["Home"];
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture;
            return Ok(await _bookAppService.GetBooks(requestDto));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddBook(AddBookInputDto addBook, CancellationToken cancellationToken)
        {
            await _bookAppService.AddBook(addBook);
            return Ok();
        }

    }
}
