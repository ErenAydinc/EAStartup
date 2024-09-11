using AutoMapper;
using Core.EADomain;
using Core.EADomain.Domains;
using EAApplication.OperationClaims.DTOs;

namespace EAApplication.OperationClaims.Profiles
{
    public class OperationClaimProfile:Profile
    {
        public OperationClaimProfile()
        {
            CreateMap<CreateOperationClaimDto, OperationClaim>().ReverseMap();
            CreateMap<UpdateOperationClaimDto, OperationClaim>().ReverseMap();
            CreateMap<DeleteOperationClaimDto, OperationClaim>().ReverseMap();

            //Get All için hem saf sınıflar map edilmeli hem de paginateler
            CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();
            CreateMap<EAPaginatedList<OperationClaim>, EAPaginatedList<OperationClaimDto>>().ReverseMap();
        }
    }
}
