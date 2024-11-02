using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.DTO.Auth;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager; // Add UserManager
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;



        public AccountController(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration,
        ILogger<AccountController> logger,
        SignInManager<ApplicationUser> signInManager) // Inject ILogger
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _logger = logger;
            _signInManager = signInManager;
        }





        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var userExist = await _userManager.FindByEmailAsync(registerDto.UserName);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var appUser = new ApplicationUser
                {
                    UserName = registerDto.UserName,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Address = registerDto.Address,
                    OfficeId = registerDto.OfficeId,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Email = registerDto.Email,
                    EmailConfirmed = true // Automatically confirm email

                };
                var role = "User";

                var result = await _userManager.CreateAsync(appUser, registerDto.Password);
                if (!result.Succeeded)
                {
                    var errorString = "";
                    foreach (var err in result.Errors)
                    {
                        errorString += err.Description + "\r\n";
                    }
                    return StatusCode(StatusCodes.Status400BadRequest,
                        new { Status = "Error", title = errorString });
                }
                else
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        await _roleManager.CreateAsync(new
                        IdentityRole(role));
                    }
                    if (await _roleManager.RoleExistsAsync(role))
                    {
                        await _userManager.AddToRoleAsync(appUser, role);

                    }
                    //return Ok(
                    //    new NewUserDTO()
                    //    {
                    //        UserName = appUser.UserName,
                    //        Email = appUser.Email,
                    //        Token = _tokenService.CreateToken(appUser)

                    //    });
                    return StatusCode(StatusCodes.Status201Created, new

                    { status = "Success", title = "User Created Successfully" });
                }


            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred during user registration.");
                return StatusCode(500, new { Status = "Error", Title = "An unexpected error occurred. Please try again later." });
            }


        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDTO)
        {
            var userExists = await _userManager.FindByNameAsync(loginDTO.UserName);
            if (userExists == null)
            {
                return Unauthorized(new { Message = "Invalid Email!" });
            }
            var result = await _signInManager.CheckPasswordSignInAsync(userExists, loginDTO.Password, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return Unauthorized("Username not found or password incorrect");
            }
            var newToken = await GenerateJWTTokenAsync(userExists);
            var roles = await _userManager.GetRolesAsync(userExists);
            var userInfo = GenerateUserInfoObject(userExists, roles);



            return Ok(new LoginServiceResponseDto()
            {
                NewToken = newToken,
                UserInfo = userInfo
            });
        }

        private async Task<string> GenerateJWTTokenAsync(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim("FirstName", user.FirstName),
            new Claim("LastName", user.LastName),
        };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
            var signingCredentials = new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256);

            var tokenObject = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: signingCredentials
                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);
            return token;
        }
        private UserInfo GenerateUserInfoObject(ApplicationUser user, IEnumerable<string> Roles)
        {
            // Instead of this, You can use Automapper packages. But i don't want it in this project
            return new UserInfo()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                OfficeId = user.OfficeId,
                Roles = Roles
            };
        }

    }
}
