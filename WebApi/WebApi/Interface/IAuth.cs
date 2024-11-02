using System.Security.Claims;
using WebApi.DTO.Auth;
using WebApi.Models;

namespace WebApi.Interface
{
    public interface IAuth
    {
        Task<ApplicationUser> SeedRolesAsync();
        Task<ApplicationUser> RegisterAsync(RegisterDto registerDto);
        Task<LoginServiceResponseDto?> LoginAsync(LoginDto loginDto);
        Task<ApplicationUser> UpdateRoleAsync(ClaimsPrincipal User, UpdateRoleDto updateRoleDto);
    }
}
