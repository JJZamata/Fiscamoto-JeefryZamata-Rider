using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class Vehicle
{
    /// <summary>
    /// Placa del vehiculo
    /// </summary>
    public string PlateNumber { get; set; } = null!;

    public string CompanyRuc { get; set; } = null!;

    public string OwnerDni { get; set; } = null!;

    /// <summary>
    /// ID del tipo de vehículo
    /// </summary>
    public int TypeId { get; set; }

    public string VehicleStatus { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    /// <summary>
    /// anio_fabricacion
    /// </summary>
    public int ManufacturingYear { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Company CompanyRucNavigation { get; set; } = null!;

    public virtual ICollection<CompliantRecord> CompliantRecords { get; set; } = new List<CompliantRecord>();

    public virtual ICollection<Insurance> Insurances { get; set; } = new List<Insurance>();

    public virtual ICollection<NonCompliantRecord> NonCompliantRecords { get; set; } = new List<NonCompliantRecord>();

    public virtual Owner OwnerDniNavigation { get; set; } = null!;

    public virtual ICollection<TechnicalReview> TechnicalReviews { get; set; } = new List<TechnicalReview>();

    public virtual VehicleType Type { get; set; } = null!;
}
