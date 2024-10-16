using DocumentTracker.Models;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Models;

namespace DocumentTrackerWebApi.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(string id);
        Task<Role> AddAsync(Role role);
        Task<Role?> UpdateAsync(string id, UpdateRoleDTO updateRoleDTO);
        Task<Role?> DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);
    }
}
