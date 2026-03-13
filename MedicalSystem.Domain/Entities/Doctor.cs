using MedicalSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MedicalSystem.Domain.Entities;

public class Doctor : EntityBase
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string NationalId { get; init; }
    public string LicenseNumber { get; private set; }
    public string PhoneNumber { get; private set; }

    public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();
    public ICollection<Specialty> Specialties { get; private set; } = new List<Specialty>();
    public ICollection<DoctorSchedule> Schedules { get; private set; } = new List<DoctorSchedule>();

    #pragma warning disable CS8618
    private Doctor() { }
    #pragma warning restore CS8618

    public Doctor(string firstName, string lastName, string nationalId, string licenseNumber, string phoneNumber)
    {
        ValidateData(firstName, lastName, nationalId, licenseNumber, phoneNumber);

        FirstName = firstName;
        LastName = lastName;
        NationalId = nationalId;
        LicenseNumber = licenseNumber;
        PhoneNumber = phoneNumber;
    }

    public void Update(string firstName, string lastName, string licenseNumber, string phoneNumber)
    {
        ValidateData(firstName, lastName, NationalId, licenseNumber, phoneNumber);

        FirstName = firstName;
        LastName = lastName;
        LicenseNumber = licenseNumber;
        PhoneNumber = phoneNumber;
    }

    private void ValidateData(string firstName, string lastName, string nationalId, string licenseNumber, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("El nombre es obligatorio", nameof(firstName));
        if (firstName.Length > 50)
            throw new ArgumentException("El nombre no puede exceder los 50 caracteres");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("El apellido es obligatorio", nameof(lastName));
        if (lastName.Length > 50)
            throw new ArgumentException("El apellido no puede exceder los 50 caracteres");

        if (string.IsNullOrWhiteSpace(nationalId))
            throw new ArgumentException("El DNI es obligatorio", nameof(nationalId));
        if (nationalId.Length < 7 || nationalId.Length > 8 || !nationalId.All(char.IsDigit))
            throw new ArgumentException("El DNI debe contener solo números y tener entre 7 u 8 dígitos");

        if (string.IsNullOrWhiteSpace(licenseNumber))
            throw new ArgumentException("El número de licencia es obligatorio", nameof(licenseNumber));
        if (licenseNumber.Length < 4)
            throw new ArgumentException("La matrícula debe contener al menos 4 caracteres");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("El número de teléfono es obligatorio", nameof(phoneNumber));
        if (!phoneNumber.All(c => char.IsDigit(c) || c == '+'))
            throw new ArgumentException("El formato del número de teléfono no es válido");
    }
}
