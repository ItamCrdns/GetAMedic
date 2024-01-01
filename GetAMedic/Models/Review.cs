namespace GetAMedic.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
