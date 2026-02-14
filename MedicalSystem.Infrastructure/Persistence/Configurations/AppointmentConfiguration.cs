using MedicalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Infrastructure.Persistence.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder) {
        builder.ToTable("Appointments");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.ScheduledDate)
            .IsRequired();

        builder.Property(a => a.Status)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        builder.HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    
    }
}
