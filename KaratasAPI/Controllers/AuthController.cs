using KaratasAPI.DTOs;
using KaratasAPI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace KaratasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {       
        private readonly JwtTokenHelper _jwtTokenHelper;

            public AuthController(JwtTokenHelper jwtTokenHelper)
            {
                _jwtTokenHelper = jwtTokenHelper;
            }

            [HttpPost("login")]
            public IActionResult Login(LoginRequestDto request)
            {
                // Replace with your actual user validation logic
                if (request.Username == "admin" && request.Password == "password")
                {
                    var token = _jwtTokenHelper.GenerateToken(request.Username, "Admin");
                    return Ok(new LoginResponseDto { Token = token });
                }
                else if (request.Username == "user" && request.Password == "password")
                {
                    var token = _jwtTokenHelper.GenerateToken(request.Username, "User");
                    return Ok(new LoginResponseDto { Token = token });
                }
                return Unauthorized("Invalid credentials");
            }
        }
    }

   
