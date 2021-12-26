using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using omzo.Controllers;

namespace omzo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : omzoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
