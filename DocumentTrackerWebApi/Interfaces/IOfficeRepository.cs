using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Models;

namespace DocumentTrackerWebApi.Interfaces
{
    public interface IOfficeRepository
    {
         Task<IEnumerable<Office>> GetAllAsync();
        Task<Office?> GetByIdAsync(int id);
        Task<Office> AddAsync(Office office);
        Task<Office?> UpdateAsync(int id,UpdateOfficeDTO updateOfficeDTO);
        Task<Office?> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}