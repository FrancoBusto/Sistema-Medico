using MedicalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Infrastructure.Persistence.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder) {
        builder.ToTable("Doctors");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(d => d.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(d => d.NationalId)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(d => d.NationalId)
            .IsUnique();

        builder.Property(d => d.LicenseNumber)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(d => d.PhoneNumber)
            .HasMaxLength(20);

        builder.HasMany(d => d.Specialties)
            .WithMany(s => s.Doctors)
            .UsingEntity(j => j.ToTable("DoctorSpecialties"));

        builder.HasQueryFilter(d => d.IsActive);
    }
}
