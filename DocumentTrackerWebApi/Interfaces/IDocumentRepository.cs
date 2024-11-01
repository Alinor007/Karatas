using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DocumentTracker.Models;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Helpers;

namespace DocumentTrackerWebApi.Interfaces
{
    public interface IDocumentRepository
    {
         Task<List<Document>> GetAllAsync();
        Task<Document?> GetByIdAsync(int id);
        Task<Document> AddAsync(Document document);
        Task<Document?> UpdateAsync(int id,UpdateDocumentDTO updatedocumentDTO);
        Task<Document?> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<int> CountAsync();  // Add this method
                                  
    }
}