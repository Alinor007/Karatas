using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using Azure;
using Azure.Identity;
using DocumentTracker.Models;
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
    [Route("api/[controller]")]

    [ApiController]

    public class AccountController:ControllerBase
        {

            private readonly UserManager<User> _userManager; // Add UserManager
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly IConfiguration _configuration;
            private readonly ILogger<AccountController> _logger;
            private readonly SignInManager<User> _signInManager;

        public AccountController(
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
        }





        [HttpPost("Register")]
            public async Task<IActionResult>Register([FromBody] RegisterDTO registerDto,string role)
            {
                //var userExist = await _userManager.FindByEmailAsync(registerDto.Email);
                //if (userExist != null)
                //{
                //    return StatusCode(StatusCodes.Status403Forbidden);
                //}
                try{
                    if(!ModelState.IsValid){
                        return BadRequest(ModelState);
                    }
                    var appUser = new User {
                        UserName = registerDto.UserName,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        Email = registerDto.Email,
                    
                    };

                    var result = await _userManager.CreateAsync(appUser,registerDto.Password);
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
                            await _userManager.AddToRoleAsync(appUser,role);

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
            

                        }catch(Exception e){
                         _logger.LogError(e, "An error occurred during user registration.");
                         return StatusCode(500, new { Status = "Error", Title = "An unexpected error occurred. Please try again later." });
                }
        

            }





        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var userExists = await _userManager.Users.FirstOrDefaultAsync(x=>x.Email == loginDTO.Email);
            if (userExists == null )
            {
                return Unauthorized(new { Message = "Invalid Email!" });
            }
            var result = await _signInManager.CheckPasswordSignInAsync(userExists,loginDTO.Password, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return Unauthorized("Email not found or password incorrect");
            }

          
            var userRoles = await _userManager.GetRolesAsync(userExists);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userExists.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                username = userExists.UserName,
                userId = userExists.Id,
                roles = userRoles,
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }



    }
}