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
            CreateMap<UserRegisterDto, AppUser>()
                .ConstructUsing(u => new AppUser { FirstName = u.FirstName, LastName = u.LastName, Email = u.Email, PasswordHash = u.Password });
            CreateMap<AppUser, UserRegisterDto>()
                .ConstructUsing(au => new UserRegisterDto(au.FirstName, au.LastName, au.Email, au.PasswordHash));
        }
    }
}
