using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Birth : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        [Required]
        public Patient Patient { get; set; }
        //public int PatientId { get; set; }
        public User User { get; set; }
        //public int UserId { get; set; }
    }
}
