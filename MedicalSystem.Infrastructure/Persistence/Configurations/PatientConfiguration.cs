using MedicalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Infrastructure.Persistence.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder) {
        builder.ToTable("Patients");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.NationalId)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(p => p.NationalId)
            .IsUnique();

        builder.Property(p => p.PhoneNumber)
            .HasMaxLength(20);
    
    }
}
