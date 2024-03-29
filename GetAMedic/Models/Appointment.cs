﻿namespace GetAMedic.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string? Note { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
