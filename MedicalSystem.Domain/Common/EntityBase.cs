using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Domain.Common;

public abstract class EntityBase
{
    public Guid Id { get; init; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; init; }

    protected EntityBase() { 
        Id = Guid.NewGuid();
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void Deactivate() {
        IsActive = false;
    }

    public void Activate() {
        IsActive = true;
    }
}
