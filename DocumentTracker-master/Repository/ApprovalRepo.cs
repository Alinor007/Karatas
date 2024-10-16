using DocumentTracker.Models;
using DocumentTrackerWebApi.Data;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Helpers;
using DocumentTrackerWebApi.Interfaces;
using DocumentTrackerWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentTrackerWebApi.Repository
{
    public class ApprovalRepo : IApproval
    {
        private readonly ApplicationDbContext _context;
        private readonly IHistoryRepository _historyRepository;

        public ApprovalRepo(ApplicationDbContext context, IHistoryRepository historyRepository)
        {
            _context = context;
            _historyRepository = historyRepository;
        }

        public async Task<DocumentApproval> AddAsync(DocumentApproval approval)
        {
            await _context.DocumentApprovals.AddAsync(approval);
            await _context.SaveChangesAsync();
            return approval;
        }

        public async Task<DocumentApproval?> DeleteAsync(int id)
        {
            var approval = await _context.DocumentApprovals.FirstOrDefaultAsync(x => x.Id == id);

            if (approval == null)
            {
                return null;
            }
            _context.DocumentApprovals.Remove(approval);
            await _context.SaveChangesAsync();
            return approval;
        }

        public async Task<List<DocumentApproval>> GetAllAsync()
        {

            return await _context.DocumentApprovals
                                .Include(d => d.Document)
                                .Include(d => d.Office)
                                .ToListAsync();
        }

        public async Task<DocumentApproval?> GetByIdAsync(int id)
        {
            return await _context.DocumentApprovals.FindAsync(id);

        }

        public async Task<DocumentApproval?> UpdateAsync(int id, UpdateDocumentApprovalDTO updateApprovalDTO)
        {

            var approvalExist = await _context.DocumentApprovals.FirstOrDefaultAsync(x => x.Id == id);
            if (approvalExist == null)
            {
                return null;
            }
            approvalExist.DocumentId = updateApprovalDTO.DocumentId;
            approvalExist.OfficeId = updateApprovalDTO.OfficeId;
            approvalExist.Comments = updateApprovalDTO.Comments;
            approvalExist.Remarks = updateApprovalDTO.Remarks;
            approvalExist.Updated = updateApprovalDTO.Updated = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();
            return approvalExist;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.DocumentApprovals.AnyAsync(e => e.Id == id);
        }

        public async Task<DocumentApproval?> ApproveOrDeclineAsync(int id, bool isApproved, string userId)
        {
            var approval = await _context.DocumentApprovals.FirstOrDefaultAsync(x => x.Id == id);

            if (approval == null)
            {
                return null;
            }

            if (isApproved)
            {
                approval.OfficeId++;

                // Increase office ID by 1, but wrap around if it reaches 5
                if (approval.OfficeId >= 6)
                {
                    approval.OfficeId = 1;
                }
                   await CreateHistoryRecord(userId, id, "Approved");
            }

            else
            {
                // Decrease office ID, but if it reaches 1, return "Declined"
                if (approval.OfficeId <= 1)
                {
                    return approval;
                }
                else
                {
                    approval.OfficeId--;
                    await CreateHistoryRecord(userId, id, "Declined");
                }
            }

                approval.Updated = DateTime.UtcNow;
                _context.DocumentApprovals.Update(approval);
                await _context.SaveChangesAsync();

                return approval;
            
        }
        private async Task CreateHistoryRecord(string userId, int documentApprovalId, string remarks)
        {
            var history = new History
            {
                UserId = userId,
                DocumentApprovalId = documentApprovalId,
                Remarks = $"{remarks}",
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            await _historyRepository.AddAsync(history);
        }
    }
}

