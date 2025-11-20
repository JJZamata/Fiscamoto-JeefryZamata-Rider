using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class Insurance
{
    public int Id { get; set; }

    public string InsuranceCompanyName { get; set; } = null!;

    public string PolicyNumber { get; set; } = null!;

    public string VehiclePlate { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly ExpirationDate { get; set; }

    public string Coverage { get; set; } = null!;

    public int LicenseId { get; set; }

    public string OwnerDni { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual DrivingLicense License { get; set; } = null!;

    public virtual Owner OwnerDniNavigation { get; set; } = null!;

    public virtual Vehicle VehiclePlateNavigation { get; set; } = null!;
}
