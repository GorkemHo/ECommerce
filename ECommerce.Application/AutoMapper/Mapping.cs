using AutoMapper;
using ECommerce.Application.Models.DTOs;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping() 
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<AppUser, UpdateProfileDto>().ReverseMap();
        }
    }
}
