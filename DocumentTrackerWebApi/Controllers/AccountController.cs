using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using Azure;
using Azure.Identity;
using DocumentTracker.Models;
using DocumentTrackerWebApi.Data;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.DTOs.Users;
using DocumentTrackerWebApi.Interfaces;
using DocumentTrackerWebApi.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DocumentTrackerWebApi.Controllers
{
    [Route("api/Account")]
    [ApiController]

    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> _userManager; // Add UserManager
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;



        public AccountController(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration,
        ILogger<AccountController> logger,
        SignInManager<User> signInManager,
        ApplicationDbContext context) // Inject ILogger
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _logger = logger;
            _signInManager = signInManager;
            _context = context;

        }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<User>>> GetUsers()
            {
                return await _context.Users.Include(u => u.Office).Include(d=>d.documents).ToListAsync();
            }
            [HttpGet("{id}")]
            public async Task<ActionResult<User>> GetUser(string Name)
            {
                var user = await _context.Users.Include(u => u.Office).FirstOrDefaultAsync(u => u.UserName == Name);

                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }

        [HttpPost("AddUser")]

        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
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
                var appUser = new User
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
                    var newToken = await GenerateJWTTokenAsync(appUser);
                    var roles = await _userManager.GetRolesAsync(appUser);
                    var userInfo = GenerateUserInfoObject(appUser, roles);

                    return Ok(
                        new LoginServiceResponseDto()
                        {
                            NewToken = newToken,
                            UserInfo = userInfo
                        });

                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred during user registration.");
                return StatusCode(500, new { Status = "Error", Title = "An unexpected error occurred. Please try again later." });
            }


        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
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