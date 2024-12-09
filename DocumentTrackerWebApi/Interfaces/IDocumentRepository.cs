using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentTracker.Models;
using DocumentTrackerWebApi.DTOs;

namespace DocumentTrackerWebApi.Interfaces
{
    public interface IDocumentRepository
    {
        Task<List<Document>> GetAllAsync();
        Task<Document?> GetByIdAsync(int id);
        Task<Document> AddAsync(Document document);
        Task<Document?> UpdateAsync(int id, UpdateDocumentDTO updateDocumentDTO);
        Task<Document?> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<(IEnumerable<Document>, int)> GetPaginatedAsync(int page, int pageSize);

    }
}
