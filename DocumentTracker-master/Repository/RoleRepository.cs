using DocumentTracker.Models;
using DocumentTrackerWebApi.Data;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocumentTrackerWebApi.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;


        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Role> AddAsync(Role role)
        {
            await _context.Role.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role?> DeleteAsync(string id)
        {
            var role = await _context.Role.FirstAsync(x => x.Id == id);

            if (role == null)
            {
                return null;
            }
            _context.Role.Remove(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.Role.AnyAsync(e => e.Id == id); throw new NotImplementedException();
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Role.ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(string id)
        {
            return await _context.Role.FindAsync(id);
        }

        public async Task<Role?> UpdateAsync(string id, UpdateRoleDTO updateOfficeDTO)
        {
            var RoleExist = await _context.Role.FirstOrDefaultAsync(x => x.Id == id);
            if (RoleExist == null)
            {
                return null;
            }
            RoleExist.Name = updateOfficeDTO.Name;
            RoleExist.Description = updateOfficeDTO.Description;
            RoleExist.Updated = updateOfficeDTO.Updated = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();
            return RoleExist;
        }
    }
}
