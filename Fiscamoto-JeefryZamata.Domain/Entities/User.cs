using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? DeviceInfo { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? LastLoginIp { get; set; }

    public string? LastLoginDevice { get; set; }

    /// <summary>
    /// Indica si el fiscalizador ya configuró su dispositivo en el primer login
    /// </summary>
    public bool DeviceConfigured { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<CompliantRecord> CompliantRecords { get; set; } = new List<CompliantRecord>();

    public virtual ICollection<NonCompliantRecord> NonCompliantRecords { get; set; } = new List<NonCompliantRecord>();

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual ICollection<TrackingStatus> TrackingStatuses { get; set; } = new List<TrackingStatus>();

    public virtual UserLastLocation? UserLastLocation { get; set; }

    public virtual ICollection<UserLocationLog> UserLocationLogs { get; set; } = new List<UserLocationLog>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
