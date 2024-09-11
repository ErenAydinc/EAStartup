using AutoMapper;
using EAApplication.Users.DTOs;
using EACrossCuttingConcerns.Generic;
using EASecurity.Authorization;

namespace EAApplication.Users.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto,User >().ReverseMap();
            CreateMap<UpdateUserDto,User >().ReverseMap();
            CreateMap<DeleteUserDto,User>().ReverseMap();

            //Get All için hem saf sınıflar map edilmeli hem de paginateler
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<EAPaginatedList<User>,EAPaginatedList<UserDto>>().ReverseMap();
        }
    }
}
