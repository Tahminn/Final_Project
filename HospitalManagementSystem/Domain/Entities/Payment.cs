using Domain.Common;

namespace Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Patient Patient { get; set; }
        //public int PatientId { get; set; }
        public int SubTotal { get; set; }
        public int Total { get; set; }
        public int Discount { get; set; }
        public int VAT { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
    }
}
