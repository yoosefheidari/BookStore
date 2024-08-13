using BookStore.Contracts;
using BookStore.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;

namespace BookStore.Implementations
{
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

        //public Task<BlobDto> GetBlobAsync(GetBlobRequestDto input)
        //{
        //    throw new System.NotImplementedException();
        //}



        public Task SaveBlobAsync(SaveBlobInputDto input)
        {
            throw new System.NotImplementedException();
        }
    }
}
