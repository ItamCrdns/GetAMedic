using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GetAMedic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager) : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(IdentityUser identityUser, string roleName)
        {
            var user = new IdentityUser
            {
                UserName = identityUser.UserName,
                Email = identityUser.Email
            };

            var result = await _userManager.CreateAsync(user, identityUser.PasswordHash);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, roleName);

                return Ok(result);
            }

            // Creates a dictionary where the e.Code its the key and e.Description its the value
            var errors = result.Errors.ToDictionary(e => e.Code, e => e.Description);

            return BadRequest(new
            {
                Errors = errors
            });
        }

        [HttpPost]
        [Route("add-roles")]
        public async Task<IActionResult> AddRole()
        {
            var doctorRole = new IdentityRole
            {
                Name = "Doctor"
            };

            var patientRole = new IdentityRole
            {
                Name = "Patient"
            };

            var result = await _roleManager.CreateAsync(doctorRole);
            var result2 = await _roleManager.CreateAsync(patientRole);

            if (result.Succeeded && result2.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
