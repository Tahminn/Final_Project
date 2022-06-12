using Service.DTOs.EntityDTOs.AccountDTOs;
using Service.DTOs.EntityDTOs.PatientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.ControllerPropDTOs.UserDTOs.GetUser
{
    public class GetUsersDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsMarried { get; set; }
        public GetGenderDTO Gender { get; set; }
        public GetOccupationDTO Occupation { get; set; }
        public GetDepartmentDTO Department { get; set; }
    }
}
