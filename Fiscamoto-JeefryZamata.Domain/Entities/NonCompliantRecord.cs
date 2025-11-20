using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class NonCompliantRecord
{
    public int Id { get; set; }

    public int ControlRecordId { get; set; }

    public int InspectorId { get; set; }

    public string CompanyRuc { get; set; } = null!;

    public DateTime InspectionDateTime { get; set; }

    public string Location { get; set; } = null!;

    public int? LicenseId { get; set; }

    public string VehiclePlate { get; set; } = null!;

    public string? Observations { get; set; }

    public string? S3FileUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Company CompanyRucNavigation { get; set; } = null!;

    public virtual ControlRecord ControlRecord { get; set; } = null!;

    public virtual User Inspector { get; set; } = null!;

    public virtual DrivingLicense? License { get; set; }

    public virtual ICollection<RecordPhoto> RecordPhotos { get; set; } = new List<RecordPhoto>();

    public virtual ICollection<RecordViolation> RecordViolations { get; set; } = new List<RecordViolation>();

    public virtual Vehicle VehiclePlateNavigation { get; set; } = null!;
}
