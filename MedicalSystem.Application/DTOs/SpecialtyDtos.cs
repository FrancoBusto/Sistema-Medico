using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalSystem.Application.DTOs;

public static class SpecialtyDtos
{
    public record SpecialtyDto(
        Guid Id,
        string Name,
        string? Description
        );

    public record CreateSpecialtyDto(
        [Required] string Name,
        string? Description
        );

    public record UpdateSpecialtyDto(
        Guid Id,
        [Required] string Name,
        string? Description
        );
}
