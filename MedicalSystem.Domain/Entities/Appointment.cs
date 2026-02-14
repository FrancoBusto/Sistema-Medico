using MedicalSystem.Domain.Common;
using MedicalSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Domain.Entities;

public class Appointment : EntityBase
{
    public DateTime ScheduledDate { get; private set; }
    public AppointmentStatus Status { get; private set; }

    public Guid DoctorId { get; init; }
    public Doctor? Doctor { get; init; }
    public Guid PatientId { get; init; }
    public Patient? Patient { get; init; }

    private Appointment() { }

    public Appointment(DateTime date, Guid doctorId, Guid patientId)
    {
        ValidateData(date, doctorId, patientId);

        ScheduledDate = date;
        Status = AppointmentStatus.Scheduled;
        DoctorId = doctorId;
        PatientId = patientId;
    }

    private void ValidateData(DateTime date, Guid doctorId, Guid patientId)
    {
        if (date < DateTime.UtcNow)
            throw new ArgumentException("No es posible generar un turno en el pasado");

        if (doctorId == Guid.Empty)
            throw new ArgumentException("El ID del médico no es válido");

        if (patientId == Guid.Empty)
            throw new ArgumentException("El ID del paciente no es válido");

    }

    public void Reschedule(DateTime newDate)
    {
        if (Status == AppointmentStatus.Completed || Status == AppointmentStatus.Cancelled)
            throw new InvalidOperationException("No se puede reprogramar un turno finalizado o cancelado");

        if (newDate < DateTime.UtcNow)
            throw new ArgumentException("La nueva fecha debe ser futura");

        ScheduledDate = newDate;
    }

    public void Confirm()
    {
        if (Status == AppointmentStatus.Cancelled)
            throw new InvalidOperationException("No se puede confirmar un turno cancelado");

        if (Status == AppointmentStatus.Completed)
            throw new InvalidOperationException("No se puede confirmar un turno ya terminado");

        if (Status == AppointmentStatus.NoShow)
            throw new InvalidOperationException("No se puede confirmar un turno de un paciente que no vino a tiempo");

        Status = AppointmentStatus.Confirmed;
    }

    public void Complete()
    {
        if (Status != AppointmentStatus.Confirmed && Status != AppointmentStatus.Scheduled)
            throw new InvalidOperationException("Solo se pueden completar turnos que estén activos o confirmador");

        Status = AppointmentStatus.Completed;
    }

    public void Cancel()
    {
        if (Status == AppointmentStatus.Completed)
            throw new InvalidOperationException("No se puede cancelar un turno ya terminado");

        if (Status == AppointmentStatus.NoShow)
            throw new InvalidOperationException("No se puede cancelar un turno de un paciente que no vino a tiempo");

        Status = AppointmentStatus.Cancelled;
    }

    public void MarkAsNoShow()
    {
        if(Status == AppointmentStatus.Completed || Status == AppointmentStatus.Cancelled)
            throw new InvalidOperationException("No se puede marcar ausencia en un turno cerrado");

        Status = AppointmentStatus.NoShow;
    }
}
