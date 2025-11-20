using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class AuditLog
{
    public ulong Id { get; set; }

    public Guid CorrelationId { get; set; }

    public DateTime Timestamp { get; set; }

    public string? Method { get; set; }

    public string? Url { get; set; }

    public ushort? StatusCode { get; set; }

    public uint? DurationMs { get; set; }

    public string? Ip { get; set; }

    public string? UserAgent { get; set; }

    public int? UserId { get; set; }

    public string? Payload { get; set; }

    public virtual User? User { get; set; }
}
