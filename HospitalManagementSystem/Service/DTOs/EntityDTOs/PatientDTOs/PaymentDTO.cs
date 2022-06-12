using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.EntityDTOs.PatientDTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public PatientDTO Patient { get; set; }
        //public int PatientId { get; set; }
        public int SubTotal { get; set; }
        public int Total { get; set; }
        public int Discount { get; set; }
        public int VAT { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
    }
}
