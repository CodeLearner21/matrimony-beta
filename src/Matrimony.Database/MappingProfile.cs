using AutoMapper;
using Matrimony.Database.Entities;
using Matrimony.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Database
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDto, AppUser>();
            CreateMap<AppUser, UserRegisterDto>();

            CreateMap<PortfolioType, PortfolioTypeDto>();
            CreateMap<PortfolioTypeDto, PortfolioType>();

            CreateMap<UserPorfolioDto, Portfolio>();
            CreateMap<Portfolio, UserPorfolioDto>();

            CreateMap<CreatePortfolioDto, Portfolio>();
            CreateMap<Portfolio, CreatePortfolioDto>();
        }
    }
}
