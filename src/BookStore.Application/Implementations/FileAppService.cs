using BookStore.Contracts;
using BookStore.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;

namespace BookStore.Implementations
{
    [RemoteService(IsEnabled = false)]
    public class FileAppService : ApplicationService, IFileAppService
    {
        private readonly IBlobContainer<MyFileContainer> _fileContainer;

        public FileAppService(IBlobContainer<MyFileContainer> fileContainer)
        {
            _fileContainer = fileContainer;
        }

        public async Task<BlobDto> GetBlobAsync(GetBlobRequestDto input)
        {
            var blob = await _fileContainer.GetAllBytesAsync(input.Name);

            return new BlobDto
            {
                Name = input.Name,
                Content = blob
            };
        }

        public async Task SaveBlobAsync(SaveBlobInputDto input)
        {
            var data = new List<byte[]>();

            foreach (IFormFile image in input.Images)
            {
                long length = image.Length;
                if (length < 0)
                    throw new BusinessException("image cannot be empty!!");
                var name = image.FileName;
                using var fileStream = image.OpenReadStream();
                byte[] bytes = new byte[length];
                fileStream.Read(bytes, 0, (int)image.Length);
                await _fileContainer.SaveAsync(name, bytes);
            }

        }
    }
}
