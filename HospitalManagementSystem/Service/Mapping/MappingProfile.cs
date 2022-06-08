using AutoMapper;
using Domain.Entities;
using Service.DTOs;
using Service.DTOs.AccountDTOs;
using Service.DTOs.PatientDTOs;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region UserEntityMapping

            CreateMap<AppUser, UserDTO>().ReverseMap();

            //CreateMap<AppUser, RegisterDTO>();
            CreateMap<RegisterDTO, AppUser>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<Gender, GenderDTO>().ReverseMap();

            CreateMap<Patient, PatientDTO>().ReverseMap();

            #endregion
        }
    }
}
