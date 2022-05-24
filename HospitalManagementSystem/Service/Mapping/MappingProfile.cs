using AutoMapper;
using Domain.Entities;
using Service.DTOs;
using Service.DTOs.PatientDTOs;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region UserEntityMapping

            CreateMap<AppUser, UserDTO>().ReverseMap();

            CreateMap<Gender, GenderDTO>().ReverseMap();

            CreateMap<Patient, PatientDTO>().ReverseMap();

            #endregion
        }
    }
}
