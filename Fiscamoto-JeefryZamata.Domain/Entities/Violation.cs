using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class Violation
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Severity { get; set; } = null!;

    public decimal UitPercentage { get; set; }

    public string? AdministrativeMeasure { get; set; }

    /// <summary>
    /// driver: conductor/propietario, company: persona jurídica
    /// </summary>
    public string Target { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<RecordViolation> RecordViolations { get; set; } = new List<RecordViolation>();
}
