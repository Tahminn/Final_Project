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

            //CreateMap<RegisterDTO, AppUser>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<AppUser, UserDTO>().ReverseMap();

            CreateMap<AppUser, RegisterDTO>().ReverseMap();

            CreateMap<Gender, GenderDTO>().ReverseMap();

            CreateMap<PatientBill, PatientBillDTO>().ReverseMap();

            CreateMap<Patient, PatientDTO>().ReverseMap();
            
            CreateMap<PatientTest, PatientTestDTO>().ReverseMap();
            
            CreateMap<PatientTriage, PatientTriageDTO>().ReverseMap();
            
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            
            CreateMap<Triage, TriageDTO>().ReverseMap();

            #endregion
        }
    }
}
