using AutoMapper;
using MedicalSystem.Application.DTOs;
using MedicalSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static MedicalSystem.Application.DTOs.DoctorScheduleDtos;

namespace MedicalSystem.Application.Mappings;

public class DoctorScheduleProfile : Profile
{
    public DoctorScheduleProfile()
    {
        CreateMap<DoctorSchedule, DoctorScheduleDto>();

        CreateMap<CreateDoctorScheduleDto, DoctorSchedule>();
    }
}
