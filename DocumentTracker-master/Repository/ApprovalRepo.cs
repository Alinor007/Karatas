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

        public ApprovalRepo(ApplicationDbContext context)
        {
            _context = context;
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

        public async Task<DocumentApproval?> ApproveOrDeclineAsync(int id, bool isApproved)
        {
            var approval = await _context.DocumentApprovals.FirstOrDefaultAsync(x => x.Id == id);

            if (approval == null)
            {
                return null;
            }

            if (isApproved)
            {
                // Increase office ID by 1, but wrap around if it reaches 5
                approval.OfficeId = (approval.OfficeId >= 5) ? 1 : approval.OfficeId + 1;
            }
            else
            {
                // Decrease office ID, but if it reaches 1, return "Declined"
                if (approval.OfficeId <= 1)
                {
                    approval.Remarks = "Declined";
                    return approval;
                }
                else
                {
                    approval.OfficeId -= 1;
                }
            }

            approval.Updated = DateTime.UtcNow;
            _context.DocumentApprovals.Update(approval);
            await _context.SaveChangesAsync();

            return approval;
        }
    }
    }

