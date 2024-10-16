using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentTrackerWebApi.Controllers;
using DocumentTrackerWebApi.Data;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Interfaces;
using DocumentTrackerWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentTrackerWebApi.Repository
{
     public class OfficeRepository : IOfficeRepository
    {
        private readonly ApplicationDbContext _context;

        public OfficeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Office>> GetAllAsync()
        {
            return await _context.Offices.ToListAsync();
        }

        public async Task<Office?> GetByIdAsync(int id)
        {
              return await _context.Offices.FindAsync(id);
        }

        public async Task<Office> AddAsync(Office office)
        {
            await _context.Offices.AddAsync(office);
            await _context.SaveChangesAsync();
            return office;
        }

        public async Task<Office?> UpdateAsync(int id,UpdateOfficeDTO updateOfficeDTO)
        {
            var OfficeExist = await _context.Offices.FirstOrDefaultAsync(x=>x.Id==id);
            if(OfficeExist==null){
                return null;
            }
                OfficeExist.Name = updateOfficeDTO.Name;
                OfficeExist.Stage = updateOfficeDTO.Stage;
                OfficeExist.Description = updateOfficeDTO.Description;
                OfficeExist.Updated = updateOfficeDTO.Updated = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            
            await _context.SaveChangesAsync();
            return OfficeExist;

        }

        public async Task<Office?> DeleteAsync(int id)
        {
            var office = await _context.Offices.FirstAsync(x=>x.Id == id);

            if (office == null)
            {
                return null;
            }
            _context.Offices.Remove(office);
                await _context.SaveChangesAsync();
                return office;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Offices.AnyAsync(e => e.Id == id);
        }

    }
}