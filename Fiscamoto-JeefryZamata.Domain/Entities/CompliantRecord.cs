using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class CompliantRecord
{
    public int Id { get; set; }

    public int ControlRecordId { get; set; }

    public int InspectorId { get; set; }

    public int LicenseId { get; set; }

    public string VehiclePlate { get; set; } = null!;

    public DateTime InspectionDateTime { get; set; }

    public string Location { get; set; } = null!;

    public string? Observations { get; set; }

    public string? S3FileUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ControlRecord ControlRecord { get; set; } = null!;

    public virtual User Inspector { get; set; } = null!;

    public virtual DrivingLicense License { get; set; } = null!;

    public virtual ICollection<RecordPhoto> RecordPhotos { get; set; } = new List<RecordPhoto>();

    public virtual Vehicle VehiclePlateNavigation { get; set; } = null!;
}
