using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentTracker.Models;
using DocumentTrackerWebApi.DTOs;

namespace DocumentTrackerWebApi.Mappers
{
    public static class HistoryMappers
    {
          // Maps History model to HistoryDTO
        public static HistoryDTO ToHistoryDto(this History historyModel)
        {
            return new HistoryDTO
            {
                Id = historyModel.Id,
                CreatedBy = historyModel.User != null ? historyModel.User.Email : string.Empty,  // Handle null case
                UserName = historyModel.User?.UserName ?? string.Empty, // Assuming navigation property is loaded
                DocumentApprovalId = historyModel.DocumentApprovalId,
                Remarks = historyModel.Remarks,
                Created = historyModel.Created,
                Updated = historyModel.Updated
            };
        }

        // Maps CreateHistoryDTO to History model
        public static History ToHistoryFromCreateDTO(this CreateHistoryDTO historyDTO)
        {
            return new History
            {
                DocumentApprovalId = historyDTO.DocumentApprovalId,
                Remarks = historyDTO.Remarks,
                Created = DateTime.UtcNow, // Set by server
                Updated = DateTime.UtcNow  // Initialize as Created time
            };
        }
          public static void UpdateHistoryFromUpdateDTO(this UpdateHistoryDTO updateHistoryDTO, History historyModel)
        {
            if (!string.IsNullOrEmpty(updateHistoryDTO.Remarks))
            {
                historyModel.Remarks = updateHistoryDTO.Remarks;
                historyModel.Updated = DateTime.UtcNow; // Update timestamp
            }
        }

    }
}