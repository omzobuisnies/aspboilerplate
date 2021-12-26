using Abp.Application.Services;
using omzo.MultiTenancy.Dto;

namespace omzo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

