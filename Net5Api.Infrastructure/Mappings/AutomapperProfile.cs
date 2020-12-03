using AutoMapper;
using Net5Api.Core.DTOs;
using Net5Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Net5Api.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() {
            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<Security, SecurityDTO>().ReverseMap();
        }
    }
}
