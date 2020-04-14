using AutoMapper;
using MyFinances.Domain.Entities;
using MyFinances.Infra.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances.Infra.Mappers
{
    public class MappingProfileDto : Profile
    {
        public MappingProfileDto()
        {
            CreateMap<User, UserDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
