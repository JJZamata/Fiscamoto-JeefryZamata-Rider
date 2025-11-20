using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class TechnicalReview
{
    /// <summary>
    /// ID único de la revisión técnica
    /// </summary>
    public string ReviewId { get; set; } = null!;

    public string VehiclePlate { get; set; } = null!;

    public DateOnly IssueDate { get; set; }

    public DateOnly ExpirationDate { get; set; }

    public string InspectionResult { get; set; } = null!;

    public string CertifyingCompany { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Vehicle VehiclePlateNavigation { get; set; } = null!;
}
