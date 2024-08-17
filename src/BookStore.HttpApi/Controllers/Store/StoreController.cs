using BookStore.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers.Store
{
    [ApiController]
    public class StoreController : BookStoreController
    {
        private readonly IStoreAppService _storeAppService;

        public StoreController(IStoreAppService storeAppService)
        {
            _storeAppService = storeAppService;
        }

        [HttpGet("SetStores")]
        public async Task<IActionResult> GetStores()
        {
            return Ok(await _storeAppService.GetStores());
        }

    }
}
