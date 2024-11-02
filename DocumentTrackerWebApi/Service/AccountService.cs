using DocumentTracker.Models;
using DocumentTrackerWebApi.Controllers;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.DTOs.Users;
using DocumentTrackerWebApi.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DocumentTrackerWebApi.Service
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<User> _userManager; // Add UserManager
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<User> _signInManager;
        public readonly IOfficeRepository _officeRepository;



        public AccountService(
        IOfficeRepository officeRepository,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration,
        ILogger<AccountController> logger,
        SignInManager<User> signInManager) // Inject ILogger

        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _logger = logger;
            _signInManager = signInManager;
            _officeRepository = officeRepository;
        }


        public async Task<LoginServiceResponseDto?> LoginAsync(LoginDTO loginDto)
        {
            var userExists = await _userManager.FindByNameAsync(loginDto.UserName);
            if (userExists == null)
                return null;

            var result = await _userManager.CheckPasswordAsync(userExists, loginDto.Password);
            if (!result)
                return null;

            
            var newToken = await GenerateJWTTokenAsync(userExists);
            var roles = await _userManager.GetRolesAsync(userExists);
            var userInfo = GenerateUserInfoObject(userExists, roles);



            return new LoginServiceResponseDto()
            {
                NewToken = newToken,
                UserInfo = userInfo
            };
        }



        public async Task<GeneralServiceResponseDto> RegisterAsync(RegisterDTO registerDto)
        {
            var isExistsUser = await _userManager.FindByNameAsync(registerDto.UserName);
            if (isExistsUser is not null)
                return new GeneralServiceResponseDto()
                {
                    IsSucceed = false,
                    StatusCode = 409,
                    Message = "UserName Already Exists"
                };

            User newUser = new User()
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                Address = registerDto.Address,
                SecurityStamp = Guid.NewGuid().ToString(),
                OfficeId = registerDto.OfficeId // Assign the selected office
            };
            var role = "User";
            var createUserResult = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (!createUserResult.Succeeded)
            {
                var errorString = "User Creation failed because: ";
                foreach (var error in createUserResult.Errors)
                {
                    errorString += " # " + error.Description;
                }
                return new GeneralServiceResponseDto()
                {
                    IsSucceed = false,
                    StatusCode = 400,
                    Message = errorString
                };
            }

            // Add a Default USER Role to all users
            await _userManager.AddToRoleAsync(newUser, role);

            return new GeneralServiceResponseDto()
            {
                IsSucceed = true,
                StatusCode = 201,
                Message = "User Created Successfully"
            };
        }
        public async Task<GeneralServiceResponseDto> SeedRolesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralServiceResponseDto> UpdateRoleAsync(ClaimsPrincipal User, UpdateRoleDto updateRoleDto)
        {
            throw new NotImplementedException();
        }


        private async Task<string> GenerateJWTTokenAsync(User user)
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
        private UserInfo GenerateUserInfoObject(User user, IEnumerable<string> Roles)
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
