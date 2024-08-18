using BookStore.Contracts;
using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers.Store
{
    [ApiController]
    [Route("Stores")]
    public class StoreController : BookStoreController
    {
        private readonly IStoreAppService _storeAppService;

        public StoreController(IStoreAppService storeAppService)
        {
            _storeAppService = storeAppService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetStores()
        {
            return Ok(await _storeAppService.GetStores());
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddStore(AddStoreInputDto inputDto)
        {
            await _storeAppService.AddStore(inputDto);
            return Ok();
        }

    }
}
