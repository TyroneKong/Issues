using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using issues.DTOs;
using issues.Models;

namespace issues.Services
{
    public interface IissueService
    {
        Task<ServiceResponse<List<GetIssueDTO>>> GetAllIssues();
        Task<ServiceResponse<List<GetIssueDTO>>> CreateIssue(AddIssueDTO newIssue);
        Task<ServiceResponse<GetIssueDTO>> GetIssueById(int id);
        Task<ServiceResponse<GetIssueDTO>> UpdateIssue(UpdateIssueDTO updatedIssue);
        Task<ServiceResponse<GetIssueDTO>> DeleteIssue(int id);
    }
}