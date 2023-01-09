using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using issues.Data;
using issues.DTOs;
using issues.Models;
using Microsoft.EntityFrameworkCore;

namespace issues.Services
{
    public class IssueService : IissueService
    {
        private readonly DataIssueContext _context;
        private readonly IMapper _mapper;
        public IssueService(IMapper mapper, DataIssueContext context)
        {
            _context = context;
            _mapper = mapper;

        }


        public async Task<ServiceResponse<List<GetIssueDTO>>> GetAllIssues()
        {
            var response = new ServiceResponse<List<GetIssueDTO>>();
            var issues = await _context.Issues.ToListAsync();
            response.Data = issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            return response;
        }
        public async Task<ServiceResponse<List<GetIssueDTO>>> CreateIssue(AddIssueDTO newIssue)
        {
            var response = new ServiceResponse<List<GetIssueDTO>>();
            var issue = _mapper.Map<Issue>(newIssue);
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            response.Data = _context.Issues.Select(i => _mapper.Map<GetIssueDTO>(i)).ToList();
            return response;
        }
        public async Task<ServiceResponse<GetIssueDTO>> GetIssueById(int id)
        {
            var response = new ServiceResponse<GetIssueDTO>();
            var issue = await _context.Issues.FirstOrDefaultAsync(i => i.Id == id);
            if (issue is null) throw new Exception($"The issue id:{id} does not exist");

            response.Data = _mapper.Map<GetIssueDTO>(issue);
            return response;
        }

        public async Task<ServiceResponse<GetIssueDTO>> UpdateIssue(UpdateIssueDTO updatedIssue)
        {
            var response = new ServiceResponse<GetIssueDTO>();
            var issue = await _context.Issues.FirstOrDefaultAsync(i => i.Id == updatedIssue.Id);
            if (issue is null) throw new Exception($"The issue id:{updatedIssue.Id} does not exist");

            issue.Title = updatedIssue.Title;
            issue.Description = updatedIssue.Description;
            issue.IssueType = updatedIssue.IssueType;
            issue.Priority = updatedIssue.Priority;
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetIssueDTO>(issue);
            return response;
        }
        public async Task<ServiceResponse<GetIssueDTO>> DeleteIssue(int id)
        {
            var response = new ServiceResponse<GetIssueDTO>();
            var issue = await _context.Issues.FirstOrDefaultAsync(i => i.Id == id);
            if (issue is null) throw new Exception($"The issue id:{id} does not exist");
            _context.Remove(issue);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetIssueDTO>(issue);
            return response;
        }
    }
}