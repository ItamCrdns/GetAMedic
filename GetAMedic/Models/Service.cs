namespace GetAMedic.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
