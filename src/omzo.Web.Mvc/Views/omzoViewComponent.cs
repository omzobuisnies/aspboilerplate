using Abp.AspNetCore.Mvc.ViewComponents;

namespace omzo.Web.Views
{
    public abstract class omzoViewComponent : AbpViewComponent
    {
        protected omzoViewComponent()
        {
            LocalizationSourceName = omzoConsts.LocalizationSourceName;
        }
    }
}
