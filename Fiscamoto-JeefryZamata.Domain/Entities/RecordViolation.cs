using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class RecordViolation
{
    public int Id { get; set; }

    public int NonCompliantRecordId { get; set; }

    public int ViolationId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual NonCompliantRecord NonCompliantRecord { get; set; } = null!;

    public virtual Violation Violation { get; set; } = null!;
}
