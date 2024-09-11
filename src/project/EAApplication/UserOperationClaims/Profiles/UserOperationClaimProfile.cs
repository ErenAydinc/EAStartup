using AutoMapper;
using EAApplication.UserOperationClaims.DTOs;
using EAApplication.Users.Commands;
using EAApplication.Users.DTOs;
using EACrossCuttingConcerns.Generic;
using EADomain;
using EASecurity.Authorization;

namespace EAApplication.UserOperationClaims.Profiles
{
    public class UserOperationClaimProfile:Profile
    {
        public UserOperationClaimProfile()
        {
            CreateMap<CreateUserOperationClaimDto, UserOperationClaim>().ReverseMap();
            CreateMap<UpdateUserOperationClaimDto, UserOperationClaim>().ReverseMap();
            CreateMap<DeleteUserOperationClaimDto, UserOperationClaim>().ReverseMap();

            //Get All için hem saf sınıflar map edilmeli hem de paginateler
            CreateMap<UserOperationClaim, UserOperationClaimDto>().ReverseMap();
            CreateMap<EAPaginatedList<UserOperationClaim>, EAPaginatedList<UserOperationClaimDto>>().ReverseMap();
        }
    }
}
