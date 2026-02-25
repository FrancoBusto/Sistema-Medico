using AutoMapper;
using MedicalSystem.Application.DTOs;
using MedicalSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static MedicalSystem.Application.DTOs.DoctorDtos;

namespace MedicalSystem.Application.Mappings;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<Doctor, DoctorDto>();

        CreateMap<CreateDoctorDto, Doctor>();
    }
}
