using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class VehicleType
{
    /// <summary>
    /// ID del tipo de vehículo
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// Nombre del tipo de vehículo
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Descripción del tipo de vehículo
    /// </summary>
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
