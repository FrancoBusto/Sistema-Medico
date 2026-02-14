using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalSystem.Application.DTOs;

public static class DoctorScheduleDtos
{
    public record DoctorScheduleDto(
        Guid Id,
        Guid DoctorId,
        DayOfWeek DayOfWeek,
        TimeSpan StartTime,
        TimeSpan EndTime
        );

    public record CreateDoctorScheduleDto(
        [Required] Guid DoctorId,
        [Required] DayOfWeek DayOfWeek,
        [Required] TimeSpan StartTime,
        [Required] TimeSpan EndTime
        );

    public record UpdateDoctorScheduleDto(
        Guid Id,
        [Required] DayOfWeek DayOfWeek,
        [Required] TimeSpan StartTime,
        [Required] TimeSpan EndTime
        );
}
