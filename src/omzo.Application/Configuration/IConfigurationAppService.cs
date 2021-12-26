using System.Threading.Tasks;
using omzo.Configuration.Dto;

namespace omzo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
