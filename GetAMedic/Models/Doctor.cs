namespace GetAMedic.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicenseNumber { get; set; }
        public string ContactInformation { get; set; }
        public string Availability { get; set; }
        public ICollection<Specialty> Specialties { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
