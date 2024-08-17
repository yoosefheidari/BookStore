using BookStore.Contracts;
using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers.File
{
    [ApiController]
    public class FileController : BookStoreController
    {
        private readonly IFileAppService _fileAppService;

        public FileController(IFileAppService fileAppService)
        {
            _fileAppService = fileAppService;
        }

        [HttpPost("SaveImage")]
        public async Task<IActionResult> SaveImages(SaveBlobInputDto images)
        {
            await _fileAppService.SaveBlobAsync(images);
            return Ok();
        }
    }
}
