using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Domain.Enums;

public enum AppointmentStatus
{
    Scheduled = 1, //programado
    Confirmed = 2, //confirmado
    Completed = 3,  //completado
    Cancelled = 4,  //cancelado
    NoShow = 5      //no vino el paciente
}
