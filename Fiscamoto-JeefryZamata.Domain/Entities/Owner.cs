using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class Owner
{
    /// <summary>
    /// DNI del propietario
    /// </summary>
    public string Dni { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    /// <summary>
    /// Teléfono del propietario
    /// </summary>
    public string Phone { get; set; } = null!;

    /// <summary>
    /// Email del propietario
    /// </summary>
    public string? Email { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Insurance> Insurances { get; set; } = new List<Insurance>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
