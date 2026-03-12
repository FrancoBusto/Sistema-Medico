using AutoMapper;
using MedicalSystem.Domain.Entities;
using MedicalSystem.Domain.Interfaces;
using MedicalSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using static MedicalSystem.Application.DTOs.DoctorDtos;

namespace MedicalSystem.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IRepository<Doctor> _repository;
    private readonly IMapper _mapper;

    public DoctorService(IRepository<Doctor> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DoctorDto>> GetAllAsync()
    {
        var doctors = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
    }

    public async Task<DoctorDto> GetByIdAsync(Guid id)
    {
        var doctor = await GetDoctorOrThrowAsync(id);

        return _mapper.Map<DoctorDto>(doctor);
    }

    public async Task<DoctorDto> CreateAsync(CreateDoctorDto createDoctorDto)
    {
        var doctor = _mapper.Map<Doctor>(createDoctorDto);
        await _repository.AddAsync(doctor);

        return _mapper.Map<DoctorDto>(doctor);
    }

    public async Task UpdateAsync(Guid id, UpdateDoctorDto updateDoctorDto)
    {
        var doctor = await GetDoctorOrThrowAsync(id);

        doctor.Update(updateDoctorDto.FirstName, updateDoctorDto.LastName, updateDoctorDto.LicenseNumber, updateDoctorDto.PhoneNumber);

        await _repository.UpdateAsync(doctor);
    }

    public async Task DeleteAsync(Guid id)
    {
        var doctor = await GetDoctorOrThrowAsync(id);

        doctor.Deactivate();

        await _repository.UpdateAsync(doctor);
    }

    private async Task<Doctor> GetDoctorOrThrowAsync(Guid id)
    {
        var doctor = await _repository.GetByIdAsync(id);

        if (doctor == null)
            throw new KeyNotFoundException($"No se encontró ningún doctor con el ID: {id}");

        return doctor;
    }
}
