using System.Threading.Tasks;
using omzo.Models.TokenAuth;
using omzo.Web.Controllers;
using Shouldly;
using Xunit;

namespace omzo.Web.Tests.Controllers
{
    public class HomeController_Tests: omzoWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}