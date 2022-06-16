using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Keyless]
    public class GetPatientsCount
    {
        public int CountPatient { get; set; }
    }
}
