using BookStore.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers.Tenant
{
    [ApiController]
    [Route("Tenants")]
    public class TenantManagementController : BookStoreController
    {
        private readonly IAppTenantAppService _tenantAppService;

        public TenantManagementController(IAppTenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddLike(int model)
        {
            //await _tenantAppService.Create(model);
            return Ok();
        }
    }
}
