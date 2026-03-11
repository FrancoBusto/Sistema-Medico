using System;
using System.Collections.Generic;
using System.Text;
using static MedicalSystem.Application.DTOs.DoctorDtos;

namespace MedicalSystem.Application.Services;

public interface IDoctorService
{
    Task<IEnumerable<DoctorDto>> GetAllAsync();

    Task<DoctorDto> GetByIdAsync(Guid id);

    Task<DoctorDto> CreateAsync(CreateDoctorDto doctorDto);

    Task UpdateAsync(Guid id, UpdateDoctorDto updateDoctorDto);

    Task DeleteAsync(Guid id);
}
