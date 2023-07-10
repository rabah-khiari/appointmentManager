using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentsManager.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100), Column(TypeName="nvarchar(100)")]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string Time { get; set; } = "12:30";
        public bool deleted { get; set; }
        public bool Done { get; set; }
        public byte LevelOfImportance { get; set; } = 2;
    }
}
