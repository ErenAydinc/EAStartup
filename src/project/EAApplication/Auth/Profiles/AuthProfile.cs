using AutoMapper;
using EAApplication.Auth.Commands;
using EAApplication.Auth.DTOs;
using EAApplication.Users.Commands;
using EAApplication.Users.DTOs;
using EAApplication.Users.Queries;
using EACrossCuttingConcerns.Generic;
using EADomain;
using EARepository.Abstractions;
using EASecurity.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.Auth.Profiles
{
    public class AuthProfile:Profile
    {
        public AuthProfile()
        {
            CreateMap<LoginUser,LoginUserDto>().ReverseMap();
            CreateMap<LoginUserCommand, LoginUser>().ReverseMap();
            CreateMap<LoginUserDto, User>().ReverseMap();

            CreateMap<RegisterUser, RegisterDto>().ReverseMap();
            CreateMap<RegisterUserCommand, RegisterUser>().ReverseMap();
            CreateMap<RegisterDto, User>().ReverseMap();
        }
    }
}
