using DocumentTracker.Models;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Helpers;

namespace DocumentTrackerWebApi.Interfaces
{
    public interface IApproval
    {
        Task<List<DocumentApproval>> GetAllAsync();
        Task<DocumentApproval?> GetByIdAsync(int id);
        Task<DocumentApproval> AddAsync(DocumentApproval approval);
        Task<DocumentApproval?> UpdateAsync(int id, UpdateDocumentApprovalDTO updateApprovalDTO);
        Task<DocumentApproval?> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<DocumentApproval?> ApproveOrDeclineAsync(int id, bool isApproved, string userId);  // New method

    }
}
