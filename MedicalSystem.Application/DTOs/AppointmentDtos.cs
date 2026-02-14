using MedicalSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalSystem.Application.DTOs;

public static class AppointmentDtos
{
    public record AppointmentDto(
        Guid Id,
        Guid DoctorId,
        string DoctorName,
        Guid PatientId,
        string PatientName,
        DateTime ScheduledDate,
        AppointmentStatus Status
        );

    public record CreateAppointmentDto(
        [Required] Guid DoctorId,
        [Required] Guid PatientId,
        [Required] DateTime ScheduledDate
        );

    public record RescheduleAppointmentDto(
        Guid Id,
        [Required] DateTime ScheduledDate
        );
}
