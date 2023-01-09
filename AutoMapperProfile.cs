using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using issues.DTOs;
using issues.Models;

namespace issues
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Issue, GetIssueDTO>();
            CreateMap<AddIssueDTO, Issue>();
            CreateMap<UpdateIssueDTO, Issue>();

        }
    }
}