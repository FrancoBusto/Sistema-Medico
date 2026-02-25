using AutoMapper;
using MedicalSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static MedicalSystem.Application.DTOs.SpecialtyDtos;

namespace MedicalSystem.Application.Mappings;

public class SpecialtyProfile : Profile
{
    public SpecialtyProfile()
    {
        CreateMap<Specialty, SpecialtyDto>();

        CreateMap<CreateSpecialtyDto, Specialty>();
    }
}
