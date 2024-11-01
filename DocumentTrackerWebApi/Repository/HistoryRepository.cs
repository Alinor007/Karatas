using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentTracker.Models;
using DocumentTrackerWebApi.Data;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Interfaces;
using DocumentTrackerWebApi.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DocumentTrackerWebApi.Repository
{
    public class HistoryRepository : IHistoryRepository
    { 
        private readonly ApplicationDbContext _context;

        public HistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieves all history records
        public async Task<List<History>> GetAllAsync()
        {
            // Include related entities if necessary
            return await _context.Histories
                                 .Include(h => h.User)
                                 .Include(h => h.DocumentApproval)
                                 .ToListAsync();
        }

        // Retrieves a history record by ID
        public async Task<History?> GetByIdAsync(int id)
        {
            return await _context.Histories
                                 .Include(h => h.User)
                                 .Include(h => h.DocumentApproval)
                                 .FirstOrDefaultAsync(h => h.Id == id);
        }

        // Adds a new history record
        public async Task<History> AddAsync(History history)


        {
            await _context.Histories.AddAsync(history);
            await _context.SaveChangesAsync();
            return history;
        }

        // Updates an existing history record using UpdateHistoryDTO
        public async Task<History?> UpdateAsync(int id, UpdateHistoryDTO updateHistoryDTO)
        {
            var history = await _context.Histories.FindAsync(id);
            if (history == null)
            {
                return null;
            }

            // Map DTO to entity
            updateHistoryDTO.UpdateHistoryFromUpdateDTO(history);

            try
            {
                _context.Histories.Update(history);
                await _context.SaveChangesAsync();
                return history;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ExistsAsync(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        // Deletes a history record by ID
        public async Task<History?> DeleteAsync(int id)
        {
            var history = await _context.Histories.FindAsync(id);
            if (history == null)
            {
                return null;
            }

            _context.Histories.Remove(history);
            await _context.SaveChangesAsync();
            return history;
        }

        // Checks if a history record exists by ID
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Histories.AnyAsync(h => h.Id == id);
        }
    }
}