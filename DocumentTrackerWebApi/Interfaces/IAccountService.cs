using DocumentTrackerWebApi.DTOs.Users;
using DocumentTrackerWebApi.DTOs;
using System.Security.Claims;

namespace DocumentTrackerWebApi.Interfaces
{
    public interface IAccountService
    {
        Task<GeneralServiceResponseDto> SeedRolesAsync();
        Task<GeneralServiceResponseDto> RegisterAsync(RegisterDTO registerDto);
        Task<LoginServiceResponseDto?> LoginAsync(LoginDTO loginDto);
        Task<GeneralServiceResponseDto> UpdateRoleAsync(ClaimsPrincipal User, UpdateRoleDto updateRoleDto);
    }
}
