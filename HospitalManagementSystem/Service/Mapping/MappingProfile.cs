using AutoMapper;
using Domain.Entities;
using Service.DTOs;
using Service.DTOs.ControllerPropDTOs.AccountDTOs;
using Service.DTOs.ControllerPropDTOs.PatientDTOs;
using Service.DTOs.ControllerPropDTOs.PatientDTOs.CreatePatients;
using Service.DTOs.ControllerPropDTOs.PatientDTOs.PutPatients;
using Service.DTOs.ControllerPropDTOs.UserDTOs;
using Service.DTOs.EntityDTOs.AccountDTOs;
using Service.DTOs.EntityDTOs.PatientDTOs;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region UserEntityMapping

            //CreateMap<RegisterDTO, User>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<User, RegisterDTO>().ReverseMap();

            CreateMap<Gender, GenderDTO>().ReverseMap();

            CreateMap<PatientBill, PatientBillDTO>().ReverseMap();

            CreateMap<Patient, PatientDTO>().ReverseMap();
            
            CreateMap<PatientTest, PatientTestDTO>().ReverseMap();
            
            CreateMap<PatientTriage, PatientTriageDTO>().ReverseMap();
            
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            
            CreateMap<Triage, TriageDTO>().ReverseMap();

            CreateMap<UserPatient, UserPatientDTO>().ReverseMap();

            CreateMap<Patient, CreatePatientsDTO>().ReverseMap();

            CreateMap<PatientTriage, CreatePatientTriageDTO>().ReverseMap();

            CreateMap<Patient, PutPatientsDTO>().ReverseMap();

            CreateMap<PatientTriage, PutPatientTriageDTO>().ReverseMap();

            CreateMap<User, CreateUserDTO>().ReverseMap();

            #endregion
        }
    }
}
