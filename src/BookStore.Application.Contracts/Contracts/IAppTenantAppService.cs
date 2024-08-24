using Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.TenantManagement;

namespace BookStore.Contracts
{
    public interface IAppTenantAppService : IApplicationService
    {
        Task<TenantDto> Create(TenantCreateDto input);
    }
}
