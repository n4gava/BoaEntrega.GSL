using BoaEntrega.GSL.Identidade.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Identidade.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterUser registerUser)
        {
            foreach (var role in registerUser.Roles)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole(role));
                    if (!roleResult.Succeeded)
                    {
                        var roleErrors = roleResult.Errors.Select(ir => ir.Description);
                        return BadRequest(string.Join("; ", roleErrors));
                    }
                }
            }
            
            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                foreach (var role in registerUser.Roles)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, role);
                    if (!addRoleResult.Succeeded)
                    {
                        var roleErrors = addRoleResult.Errors.Select(ir => ir.Description);
                        return BadRequest(string.Join("; ", roleErrors));
                    }
                }

                var fullJwt = await GetFullJwt(user.Email);

                return Ok(fullJwt);
            }

            var errors = result.Errors.Select(ir => ir.Description);

            return BadRequest(string.Join("; ", errors));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(loginUser.Email);

                var fullJwt = await GetFullJwt(user.Email);

                return Ok(fullJwt);
            }

            if (result.IsLockedOut)
            {
                return BadRequest("This user is temporarily blocked");
            }

            return BadRequest("Incorrect user or password");
        }

        private async Task<string> GetFullJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var tokenDescription = await GetSecurityTokenDescriptor(user);

            return GenerateToken(tokenDescription);
        }

        private async Task<SecurityTokenDescriptor> GetSecurityTokenDescriptor(IdentityUser user)
        {
            var key = Encoding.ASCII.GetBytes("9a35787f-665f-4439-b5bc-b6a8dd08987a");

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.NameId, user.Id));
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            var tokenDescription = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMonths(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = claimsIdentity
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claimsIdentity.AddClaim(new Claim("Role", role));
            }

            return tokenDescription;
        }

        private string GenerateToken(SecurityTokenDescriptor tokenDescription)
        {
            var tokenHandle = new JwtSecurityTokenHandler();
            return tokenHandle.WriteToken(tokenHandle.CreateToken(tokenDescription));
        }
    }
}
