using System.Threading.Tasks;
using Abp.Application.Services;
using omzo.Sessions.Dto;

namespace omzo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
