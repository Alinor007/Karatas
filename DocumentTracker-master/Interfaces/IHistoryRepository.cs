using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentTracker.Models;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Helpers;

namespace DocumentTrackerWebApi.Interfaces
{
    public interface IHistoryRepository
    {
        Task<List<History>> GetAllAsync();
        Task<History?> GetByIdAsync(int id);
        Task<History> AddAsync(History history);
        Task<History?> UpdateAsync(int id,UpdateHistoryDTO updateHistoryDTO);
        Task<History?> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}