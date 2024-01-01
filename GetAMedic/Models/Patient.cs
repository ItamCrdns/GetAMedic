namespace GetAMedic.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactInformation { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
