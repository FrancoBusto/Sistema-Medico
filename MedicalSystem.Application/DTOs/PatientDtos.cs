using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalSystem.Application.DTOs;

public static class PatientDtos
{
    public record PatientDto(
        Guid Id,
        string FirstName,
        string LastName,
        string NationalId,
        string PhoneNumber
        );

    public record CreatePatientDto(
        [Required] string FirstName,
        [Required] string LastName,
        [Required] string NationalId,
        [Required] string PhoneNumber
        );

    public record UpdatePatientDto(
        Guid Id,
        [Required] string FirstName,
        [Required] string LastName,
        [Required] string PhoneNumber
        );
}
