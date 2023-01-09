using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using issues.Data;
using issues.DTOs;
using issues.Models;
using issues.Services;
using Microsoft.AspNetCore.Mvc;

namespace issues.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueController : ControllerBase
    {
        private readonly IissueService _issueService;
        public IssueController(IissueService issueService)
        {
            _issueService = issueService;
        }


        [HttpGet("getAllIssues")]

        public async Task<ActionResult<ServiceResponse<List<GetIssueDTO>>>> Get()
        {
            return Ok(await _issueService.GetAllIssues());
        }


        [HttpPost("createNewIssue")]

        public async Task<ActionResult<ServiceResponse<List<GetIssueDTO>>>> CreateIssue(AddIssueDTO newIssue)
        {
            return Ok(await _issueService.CreateIssue(newIssue));
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<ServiceResponse<List<GetIssueDTO>>>> GetIssueById(int id)
        {
            return Ok(await _issueService.GetIssueById(id));
        }

        [HttpPut("updateIssue")]
        public async Task<ActionResult<ServiceResponse<GetIssueDTO>>> UpdateIssue(UpdateIssueDTO updatedIssue)
        {
            return Ok(await _issueService.UpdateIssue(updatedIssue));
        }
        [HttpDelete("deleteIssue")]
        public async Task<ActionResult<ServiceResponse<GetIssueDTO>>> DeleteIssue(int id)
        {
            return Ok(await _issueService.DeleteIssue(id));
        }
    }
}