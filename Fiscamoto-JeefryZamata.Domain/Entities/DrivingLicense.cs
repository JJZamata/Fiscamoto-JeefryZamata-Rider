using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class DrivingLicense
{
    /// <summary>
    /// ID único de la licencia
    /// </summary>
    public int LicenseId { get; set; }

    public string DriverDni { get; set; } = null!;

    public string LicenseNumber { get; set; } = null!;

    public string Category { get; set; } = null!;

    public DateOnly IssueDate { get; set; }

    public DateOnly ExpirationDate { get; set; }

    public string IssuingEntity { get; set; } = null!;

    public string Restrictions { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<CompliantRecord> CompliantRecords { get; set; } = new List<CompliantRecord>();

    public virtual Driver DriverDniNavigation { get; set; } = null!;

    public virtual ICollection<Insurance> Insurances { get; set; } = new List<Insurance>();

    public virtual ICollection<NonCompliantRecord> NonCompliantRecords { get; set; } = new List<NonCompliantRecord>();
}
