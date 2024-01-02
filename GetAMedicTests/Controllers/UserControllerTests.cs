using FakeItEasy;
using GetAMedic.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GetAMedicTests.Controllers
{
    public class UserControllerTests
    {
        private readonly UserController _userController;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserControllerTests()
        {
            _userManager = A.Fake<UserManager<IdentityUser>>();
            _roleManager = A.Fake<RoleManager<IdentityRole>>();

            _userController = new UserController(_userManager, _roleManager);
        }

        [Fact]
        public async Task UserController_Register_ReturnsOk()
        {
            // Arrange
            var user = new IdentityUser
            {
                UserName = "fakeusername",
                Email = "fake@gmail.com"
            };

            A.CallTo(() => _userManager.CreateAsync(A<IdentityUser>._, A<string>._)).Returns(IdentityResult.Success);

            var result = await _userController.Register(user, "Patient");

            // Act
            Assert.NotNull(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
        }

        [Fact]
        public async Task UserController_Register_ReturnsBadRequest()
        {
            var user = new IdentityUser
            {
                UserName = "fakeusername",
                Email = ""
            };

            var failedIdentityResult = IdentityResult.Failed(new IdentityError
            {
                Code = "fakecode",
                Description = "fakedescription"
            });

            A.CallTo(() => _userManager.CreateAsync(A<IdentityUser>._, A<string>._)).Returns(failedIdentityResult);

            var result = await _userController.Register(user, "Patient");

            Assert.NotNull(result);
            Assert.Equal(400, ((BadRequestObjectResult)result).StatusCode);
        }
    }
}
