using AutoMapper;
using Core.EADomain.Domains;
using EAApplication.Auth.Commands;
using EAApplication.Auth.DTOs;
using EADomain;

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
