using MedicalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Infrastructure.Persistence.Configurations;

public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure(EntityTypeBuilder<Specialty> builder) {
        builder.ToTable("Specialties");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.Description)
            .HasMaxLength(200);
    
    }
}
