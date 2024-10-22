using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.XPath;
using DocumentTracker.Models;
using DocumentTrackerWebApi.Data;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Helpers;
using DocumentTrackerWebApi.Interfaces;
using DocumentTrackerWebApi.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace DocumentTrackerWebApi.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager; // Add UserManager

        public DocumentRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager; // Initialize UserManage
        }

        // Retrieves all document records
         public async Task<List<Document>> GetAllAsync()
        {
            // Include related entities if necessary (e.g., User)
            return await _context.Documents
                                 .Include(d => d.User)
                                 .ToListAsync();
        }

        // Retrieves a document record by ID
        public async Task<Document?> GetByIdAsync(int id)
        {
            return await _context.Documents
                                 .Include(d => d.User)
                                 .FirstOrDefaultAsync(d => d.Id == id);
        }

        // Adds a new document record
        public async Task<Document> AddAsync(Document document)
        {


            document.Created = DateTime.UtcNow; // Automatically set Created date
            document.Updated = DateTime.UtcNow; // Set Updated date to now
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync(); // Saves and generates Document.Id
            return document;
        }

        // Updates an existing document record using UpdateDocumentDTO
        public async Task<Document?> UpdateAsync(int id, UpdateDocumentDTO updateDocumentDTO)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return null;
            }

            // Map DTO to entity
            updateDocumentDTO.UpdateDocumentFromUpdateDTO(document);

            try
            {
                _context.Documents.Update(document);
                await _context.SaveChangesAsync();
                return document;
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

        // Deletes a document record by ID
        public async Task<Document?> DeleteAsync(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return null;
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return document;
        }

        // Checks if a document record exists by ID
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Documents.AnyAsync(d => d.Id == id);
        }
        public async Task<int> CountAsync()
        {
            return await _context.Documents.CountAsync();
        }




    }
}