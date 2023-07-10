namespace AppointmentsManager.Models
{
    public class Filter
    {
        public byte? LevelOfImportance { get; set; } = 2;
        public string? SpecifiedTime { get; set; }
        public DateTime? SpecifiedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
   
        public bool deleted { get; set; }
        public bool Done { get; set; }
        public bool All { get; set; }
        
    }
}
