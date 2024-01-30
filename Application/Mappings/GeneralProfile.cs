using Application.DTOs;
using Application.ViewModels;
using AutoMapper;
using Database.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            CreateMap<SaveProjectViewModel, Project>()
                .ReverseMap();

            /*CreateMap<UserViewModel, ApplicationUser>()
                .ForMember(x => x.Project, opt => opt.Ignore())
                .ForMember(x => x.ProjectId, opt => opt.Ignore())
                .ReverseMap();*/

            CreateMap<Project, ProjectResponse>()
                .ReverseMap();

            CreateMap<SaveUserViewModel, User>()
                .ReverseMap();
        }
    }
}
