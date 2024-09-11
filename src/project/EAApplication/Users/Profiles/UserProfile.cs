using AutoMapper;
using Core.EADomain;
using Core.EADomain.Domains;
using EAApplication.Users.DTOs;

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
