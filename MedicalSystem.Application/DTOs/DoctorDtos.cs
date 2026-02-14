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
        [Required] string FirstName,
        [Required] string LastName,
        [Required] string NationalId,
        [Required] string LicenseNumber,
        [Required] string PhoneNumber
        );

    public record UpdateDoctorDto(
        Guid Id,
        [Required] string FirstName,
        [Required] string LastName,
        [Required] string LicenseNumber,
        [Required] string PhoneNumber
        );
}
