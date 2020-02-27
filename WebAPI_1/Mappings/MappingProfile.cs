using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_1.Models;
using AutoMapper;
using WebAPI_1.DTOs;

namespace WebAPI_1.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserForListDTO>();
            CreateMap<User, UserForDetailsDto>();
        }
    }
}
