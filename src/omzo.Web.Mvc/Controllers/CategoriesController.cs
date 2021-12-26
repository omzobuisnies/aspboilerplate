using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using omzo.Authorization;
using omzo.Controllers;
using omzo.MultiTenancy;
using omzo.Categories;

namespace omzo.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class CategoriesController : omzoControllerBase
    {
        private readonly CategoryAppService _categoriesAppServices;

        public CategoriesController(CategoryAppService categoriesAppServices)
        {
            _categoriesAppServices = categoriesAppServices;
        }

        public ActionResult Index() => View();

        public async Task<ActionResult> EditModal(int categoryid)
        {
            var tenantDto = await _categoriesAppServices.GetAsync(new EntityDto(categoryid));
            return PartialView("_EditModal", tenantDto);
        }
    }
}
