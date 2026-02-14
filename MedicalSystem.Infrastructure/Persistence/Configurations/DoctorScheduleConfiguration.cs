using MedicalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Infrastructure.Persistence.Configurations;

public class DoctorScheduleConfiguration : IEntityTypeConfiguration<DoctorSchedule>
{
    public void Configure(EntityTypeBuilder<DoctorSchedule> builder) {
        builder.ToTable("DoctorSchedules");

        builder.HasKey(ds => ds.Id);

        builder.Property(ds => ds.DayOfWeek)
            .HasConversion<string>()
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(ds => ds.StartTime)
            .HasColumnType("time")
            .IsRequired();

        builder.Property(ds => ds.EndTime)
            .HasColumnType("time")
            .IsRequired();

        builder.HasOne(ds => ds.Doctor)
            .WithMany(d => d.Schedules)
            .HasForeignKey(ds => ds.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
    
    }
}
