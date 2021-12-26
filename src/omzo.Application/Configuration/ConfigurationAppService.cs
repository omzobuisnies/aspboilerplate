using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using omzo.Configuration.Dto;

namespace omzo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : omzoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
