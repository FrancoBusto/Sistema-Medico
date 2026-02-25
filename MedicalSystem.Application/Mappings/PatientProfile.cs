using AutoMapper;
using MedicalSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static MedicalSystem.Application.DTOs.PatientDtos;

namespace MedicalSystem.Application.Mappings;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientDto>();

        CreateMap<CreatePatientDto, Patient>();
    }
}
