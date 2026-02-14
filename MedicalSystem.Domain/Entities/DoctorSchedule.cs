using MedicalSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Domain.Entities;

public class DoctorSchedule : EntityBase
{
    public DayOfWeek DayOfWeek { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }

    public Guid DoctorId { get; init; }
    public Doctor? Doctor { get; init; }

    private DoctorSchedule() { }

    public DoctorSchedule(Guid doctorId, DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime)
    {
        ValidateData(doctorId, startTime, endTime);

        DoctorId = doctorId;
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        EndTime = endTime;
    }

    private void ValidateData(Guid doctorId, TimeSpan startTime, TimeSpan endTime)
    {
        if (doctorId == Guid.Empty)
            throw new ArgumentException("El ID del médico es obligatorio");

        ValidateHours(startTime, endTime);
    }

    private void ValidateHours(TimeSpan startTime, TimeSpan endTime)
    {
        if (endTime <= startTime)
            throw new ArgumentException("La hora de fin debe ser posterior a la hora de inicio");
    }

    public void Update(TimeSpan newStartTime, TimeSpan newEndTime, DayOfWeek newDayOfWeek)
    {
        ValidateHours(newStartTime, newEndTime);

        StartTime = newStartTime;
        EndTime = newEndTime;
        DayOfWeek = newDayOfWeek;
    }
}
