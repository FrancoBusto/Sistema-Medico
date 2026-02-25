using AutoMapper;
using MedicalSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static MedicalSystem.Application.DTOs.AppointmentDtos;

namespace MedicalSystem.Application.Mappings;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<Appointment, AppointmentDto>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => $"{src.Doctor!.FirstName} {src.Doctor.LastName}"))
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => $"{src.Patient!.FirstName} {src.Patient.LastName}"));

        CreateMap<CreateAppointmentDto, Appointment>();
    }
}
