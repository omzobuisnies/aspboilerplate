using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace omzo.Web.Views
{
    public abstract class omzoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected omzoRazorPage()
        {
            LocalizationSourceName = omzoConsts.LocalizationSourceName;
        }
    }
}
