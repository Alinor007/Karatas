using DocumentTracker.Models;
using DocumentTrackerWebApi.DTOs;
using DocumentTrackerWebApi.Models;

namespace DocumentTrackerWebApi.Mappers
{
    public static class ApprovalMappers
    {


        public static DocumentApprovalDTO ToApprovalDto(this DocumentApproval ApprovalModel)
        {
            return new DocumentApprovalDTO
            {
                Id = ApprovalModel.Id,
                DocumentId = ApprovalModel.DocumentId,
                OfficeId = ApprovalModel.OfficeId,
                Comments = ApprovalModel.Comments,
                Remarks = ApprovalModel.Remarks,
                Created = ApprovalModel.Created,
                Updated = ApprovalModel.Updated,

            };
        }
        public static DocumentApproval ToApprovalFromCreateDTO(this CreateDocumentApprovalDTO ApprovalDTO)
        {

            return new DocumentApproval
            {
                DocumentId = ApprovalDTO.DocumentId,
                OfficeId = ApprovalDTO.OfficeId,
                Comments = ApprovalDTO.Comments,
                Remarks = ApprovalDTO.Remarks,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };
        }
    }
}