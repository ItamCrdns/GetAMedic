namespace GetAMedic.Models
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
