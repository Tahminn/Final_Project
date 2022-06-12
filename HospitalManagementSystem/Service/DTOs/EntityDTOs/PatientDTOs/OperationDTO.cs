using Service.DTOs.EntityDTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.EntityDTOs.PatientDTOs
{
    public class OperationDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public PatientDTO Patient { get; set; }
        public UserDTO User { get; set; }
    }
}
