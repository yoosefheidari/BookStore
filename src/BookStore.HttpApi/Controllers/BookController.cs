using BookStore.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    public class BookController : BookStoreController
    {
        private readonly IBookAppService _bookAppService;

        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }
        [HttpGet("getBooks")]
        public async Task<IActionResult> GetStoreBooks()
        {
            //var str = L["HelloWorld"];
            return Ok(await _bookAppService.GetStoreBooks());
        }

        [HttpGet("getStores")]
        public async Task<IActionResult> GetStores()
        {
            //var str = L["HelloWorld"];
            return Ok(await _bookAppService.GetStores());
        }
    }
}
