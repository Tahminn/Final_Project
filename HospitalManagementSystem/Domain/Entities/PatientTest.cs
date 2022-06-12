using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class PatientTest : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public Patient Patient { get; set; }
        //public int PatientId { get; set; }
        public User User { get; set; }
        //public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string TestResult { get; set; }
        public string Comment { get; set; }
        public int Fee { get; set; }
    }
}
