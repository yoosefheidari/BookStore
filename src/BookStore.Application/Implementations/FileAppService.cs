using BookStore.Contracts;
using BookStore.Dtos;
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

        public async Task<string> SaveBlobAsync(SaveBlobInputDto input)
        {
            var data = new List<byte[]>();

            long length = input.Image.Length;
            if (length < 0)
                throw new BusinessException("image cannot be empty!!");
            var name = input.Image.FileName;
            using var fileStream = input.Image.OpenReadStream();
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)input.Image.Length);
            await _fileContainer.SaveAsync(name, bytes);
            return name;


        }
    }
}
