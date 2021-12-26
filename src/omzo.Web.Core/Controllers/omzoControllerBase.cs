using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace omzo.Controllers
{
    public abstract class omzoControllerBase: AbpController
    {
        protected omzoControllerBase()
        {
            LocalizationSourceName = omzoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
