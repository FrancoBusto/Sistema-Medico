using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalSystem.Application.DTOs;

public static class DoctorDtos
{
    public record DoctorDto(
        Guid Id,
        string FirstName,
        string LastName,
        string NationalId,
        string LicenseNumber,
        string PhoneNumber
        );

    public record CreateDoctorDto(
        string FirstName,
        string LastName,
        string NationalId,
        string LicenseNumber,
        string PhoneNumber
        );

    public record UpdateDoctorDto(
        Guid Id,
        string FirstName,
        string LastName,
        string LicenseNumber,
        string PhoneNumber
        );
}
