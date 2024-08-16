using AutoMapper;
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

namespace EAApplication.Users.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<LoginUser,LoginUserDto>().ReverseMap();
            CreateMap<LoginUserCommand, LoginUser>().ReverseMap();
            CreateMap<LoginUserDto, User>().ReverseMap();
            CreateMap<CreateUserDto,User >().ReverseMap();
            CreateMap<UpdateUserDto,User >().ReverseMap();
            CreateMap<DeleteUserDto,User>().ReverseMap();

            //Get All için hem saf sınıflar map edilmeli hem de paginateler
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<EAPaginatedList<User>,EAPaginatedList<UserDto>>().ReverseMap();
        }
    }
}
