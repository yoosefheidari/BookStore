using BookStore.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace BookStore.Contracts
{
    public interface IStoreAppService : IApplicationService, IScopedDependency
    {
        Task<List<StoreOutputDto>> GetStores();
        Task AddStore(AddStoreInputDto input);
    }
}
