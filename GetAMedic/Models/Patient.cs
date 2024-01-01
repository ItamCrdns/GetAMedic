namespace GetAMedic.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string? Picture { get; set; }
        public string LastName { get; set; }
        public string ContactInformation { get; set; }
        //public string Email { get; set; }
        //public string PhoneNumber { get; set; }
        //public int AccessFailedCount { get; set; }
        //public bool LockoutEnabled { get; set; }
        //public DateTimeOffset LockoutEnd { get; set; }
        //public string PasswordHash { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
