using AutoMapper;
using CoreWebApi.Models;
using CoreWebApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
            CreateMap<Trail, TrailsDto>().ReverseMap();
            CreateMap<Trail, TrailUpsertDto>().ReverseMap();
        }
    }
}
