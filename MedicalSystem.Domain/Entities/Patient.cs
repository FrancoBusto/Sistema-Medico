using MedicalSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Domain.Entities;

public class Patient : EntityBase
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string NationalId { get; init; }
    public string PhoneNumber { get; private set; }

    public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();

    #pragma warning disable CS8618
    private Patient() { }
    #pragma warning restore CS8618

    public Patient(string firstName, string lastName, string nationalId, string phoneNumber)
    {
        ValidateData(firstName, lastName, nationalId, phoneNumber);

        FirstName = firstName;
        LastName = lastName;
        NationalId = nationalId;
        PhoneNumber = phoneNumber;
    }

    public void Update(string firstName, string lastName, string phoneNumber)
    {
        ValidateData(firstName, lastName, NationalId, phoneNumber);

        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }

    private void ValidateData(string firstName, string lastName, string nationalId, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentNullException(nameof(firstName), "El nombre es obligatorio");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentNullException(nameof(lastName), "El apellido es obligatorio");

        if (string.IsNullOrWhiteSpace(nationalId))
            throw new ArgumentException("El DNI es obligatorio");

        if (nationalId.Length < 7 || !nationalId.All(char.IsDigit))
            throw new ArgumentException("El DNI no es valido");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentNullException(nameof(phoneNumber), "El número de teléfono es obligatorio");
    }
}
