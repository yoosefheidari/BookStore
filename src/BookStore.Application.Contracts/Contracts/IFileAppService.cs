using BookStore.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace BookStore.Contracts
{
    public interface IFileAppService : IApplicationService, IScopedDependency
    {
        Task<string> SaveBlobAsync(SaveBlobInputDto input);
        Task<BlobDto> GetBlobAsync(GetBlobRequestDto input);
    }
}
