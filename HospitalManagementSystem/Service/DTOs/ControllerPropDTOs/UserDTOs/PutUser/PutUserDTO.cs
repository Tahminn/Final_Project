using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.ControllerPropDTOs.UserDTOs.PutUser
{
    public class PutUserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool EmailConfirmed { get; set; } = true;
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsMarried { get; set; }
        public int GenderId { get; set; }
        public int OccupationId { get; set; }
        public int DepartmentId { get; set; }

    }
}
