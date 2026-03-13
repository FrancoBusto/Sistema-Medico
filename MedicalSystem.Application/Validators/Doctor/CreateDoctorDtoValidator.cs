using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using static MedicalSystem.Application.DTOs.DoctorDtos;

namespace MedicalSystem.Application.Validators.Doctor;

public class CreateDoctorDtoValidator : AbstractValidator<CreateDoctorDto>
{
    public CreateDoctorDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("El nombre es obligatorio")
            .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("El appelido es obligatorio")
            .MaximumLength(50).WithMessage("El apellido no puede exceder los 50 caracteres");

        RuleFor(x => x.NationalId)
            .NotEmpty().WithMessage("El DNI es obligatorio")
            .Matches("^[0-9]{7,8}$").WithMessage("El DNI debe contener solo números y tener entre 7 u 8 dígitos");

        RuleFor(x => x.LicenseNumber)
            .NotEmpty().WithMessage("La matrícula es obligatoria")
            .MinimumLength(4).WithMessage("La matrícula debe contener al menos 4 caracteres");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("El número de teléfono es obligatorio")
            .Matches(@"^\+?[0-9]*$").WithMessage("El formato del número de teléfono no es válido");

    }
}
