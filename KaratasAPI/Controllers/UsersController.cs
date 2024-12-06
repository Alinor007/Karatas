using AutoMapper;
using KaratasAPI.Data;
using KaratasAPI.DTOs;
using KaratasAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KaratasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // User Registration
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserCreateDto userCreateDto)
        {
            if (_context.Users.Any(u => u.Username == userCreateDto.Username))
            {
                return BadRequest("Username is already taken.");
            }

            var user = _mapper.Map<User>(userCreateDto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password); // Hash password
            user.Role = "User";

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        // Admin: Edit User Role
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/role")]
        public async Task<ActionResult> UpdateUserRole(int id, [FromBody] string role)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("User not found.");

            if (role != "Admin" && role != "User")
            {
                return BadRequest("Invalid role. Role must be 'Admin' or 'User'.");
            }

            user.Role = role;
            await _context.SaveChangesAsync();

            return Ok($"User role updated to {role}.");
        }

        // User Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("User not found.");

            // Update user properties using the DTO
            if (!string.IsNullOrEmpty(userUpdateDto.Username))
                user.Username = userUpdateDto.Username;

            if (!string.IsNullOrEmpty(userUpdateDto.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(userUpdateDto.Password); // Hash password if provided

            if (!string.IsNullOrEmpty(userUpdateDto.Role))
            {
                if (userUpdateDto.Role != "Admin" && userUpdateDto.Role != "User")
                    return BadRequest("Invalid role. Role must be 'Admin' or 'User'.");

                user.Role = userUpdateDto.Role;
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("User updated successfully.");
        }
    }
}
