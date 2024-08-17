using BookStore.Contracts;
using Microsoft.AspNetCore.Mvc;

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

        //[HttpPost("SaveImage")]
        //public async Task<IActionResult> SaveImages(SaveBlobInputDto images)
        //{
        //    await _fileAppService.SaveBlobAsync(images);
        //    return Ok();
        //}
    }
}
