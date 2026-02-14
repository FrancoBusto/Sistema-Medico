using MedicalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MedicalSystem.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optiones) : base(optiones) {
    
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
    public DbSet<Specialty> Specialties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
