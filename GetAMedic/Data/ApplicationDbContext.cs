using GetAMedic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GetAMedic.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<IdentityUser>(options)
    {
        // Tables
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Service> Services { get; set; } // For patients
        public DbSet<Appointment> Appointments { get; set; } // For both doctors and patients
        public DbSet<Review> Reviews { get; set; } // Reviews for a certain doctor
        public DbSet<Specialty> Specialties { get; set; } // For doctors

        // Relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Doctor and Specialty
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Specialties)
                .WithMany(s => s.Doctors)
                .UsingEntity<DoctorSpecialty>();

            // Doctor and Appointment
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId);

            // Doctor and Patient
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Patients)
                .WithMany(p => p.Doctors)
                .UsingEntity<DoctorPatient>();

            // Doctor and Review
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Reviews)
                .WithOne(r => r.Doctor)
                .HasForeignKey(r => r.DoctorId);

            // Doctor and Service
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Services)
                .WithOne(s => s.Doctor)
                .HasForeignKey(s => s.DoctorId);

            // Patient and Service
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Services)
                .WithOne(s => s.Patient)
                .HasForeignKey(s => s.PatientId);

            // Patient and Review
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Patient)
                .HasForeignKey(r => r.PatientId);

            // Patient and Appointment
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId);

            // Patient and Transaction
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Transactions)
                .WithOne(t => t.Patient)
                .HasForeignKey(t => t.PatientId);

            // Service and transaction
            modelBuilder.Entity<Service>()
                .HasMany(s => s.Transactions)
                .WithOne(t => t.Service)
                .HasForeignKey(t => t.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            // Fix truncated decimal values
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
