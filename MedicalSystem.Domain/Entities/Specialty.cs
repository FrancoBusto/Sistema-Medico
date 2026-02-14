using MedicalSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace MedicalSystem.Domain.Entities;

public class Specialty : EntityBase
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public ICollection<Doctor> Doctors { get; private set; } = new List<Doctor>();

    #pragma warning disable CS8618
    private Specialty() { }
    #pragma warning restore CS8618

    public Specialty(string name, string? description = null)
    {
        ValidateData(name);

        Name = name;
        Description = description;
    }

    private void ValidateData(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("El nombre de la especialidad es obligatorio");
    }

    public void Update(string newName, string? newDescription)
    {
        ValidateData(newName);

        Name = newName;

        Description = string.IsNullOrWhiteSpace(newDescription) ? null : newDescription;
    }
}
