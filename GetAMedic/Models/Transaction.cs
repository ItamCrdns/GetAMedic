namespace GetAMedic.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int PatientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public Patient Patient { get; set; }
        public Service Service { get; set; }
    }
}
