using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DocumentTracker.Models;
using DocumentTrackerWebApi.Data;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Interfaces;
using DocumentTrackerWebApi.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DocumentTrackerWebApi.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public DocumentRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Retrieves all document records, including User details if available
        public async Task<List<Document>> GetAllAsync()
        {
            return await _context.Documents
                                 .Include(d => d.owner)
                                 .ToListAsync();
        }

        // Retrieves a document record by ID, including User details if available
        public async Task<Document?> GetByIdAsync(int id)
        {
            return await _context.Documents
                                 .Include(d => d.owner)
                                 .FirstOrDefaultAsync(d => d.Id == id);
        }

        // Adds a new document record
        public async Task<Document> AddAsync(Document document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
            return document;
        }

        // Updates an existing document record using UpdateDocumentDTO
        public async Task<Document?> UpdateAsync(int id, UpdateDocumentDTO updateDocumentDTO)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null) return null;

            updateDocumentDTO.UpdateDocumentFromUpdateDTO(document);

            document.DateUpdated = DateTime.UtcNow;

            try
            {
                _context.Documents.Update(document);
                await _context.SaveChangesAsync();
                return document;
            }
            catch (DbUpdateConcurrencyException)
            {
                return await ExistsAsync(id) ? document : null;
            }
        }

        // Deletes a document record by ID
        public async Task<Document?> DeleteAsync(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null) return null;

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return document;
        }

        // Checks if a document record exists by ID
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Documents.AnyAsync(d => d.Id == id);
        }

        public async Task<(IEnumerable<Document>, int)> GetPaginatedAsync(int page, int pageSize)
        {
            var query = _context.Documents.AsQueryable();
            var totalDocuments = await query.CountAsync();

            var documents = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(d => d.owner)
                .ToListAsync();

            return (documents, totalDocuments);
        }
    }
}
