using Abp.Application.Services;

namespace BookStore.Implementations
{
    [RemoteService(IsEnabled = false)]
    public class AppTenantAppService : ApplicationService//, IAppTenantAppService
    {
        //private readonly ITenantManager _tenantManager;

        //public AppTenantAppService(ITenantManager tenantManager)
        //{
        //    _tenantManager = tenantManager;
        //}

        //public async Task<TenantDto> Create(TenantCreateDto input)
        //{
        //    var tenant = await _tenantManager.CreateAsync(input.Name);
        //    var output = ObjectMapper.Map<TenantDto>(tenant);
        //    return output;
        //}

    }
}
