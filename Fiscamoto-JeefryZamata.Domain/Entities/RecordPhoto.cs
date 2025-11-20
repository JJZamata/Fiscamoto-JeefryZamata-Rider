using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class RecordPhoto
{
    public int Id { get; set; }

    public int? CompliantRecordId { get; set; }

    public int? NonCompliantRecordId { get; set; }

    public int PhotoId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual CompliantRecord? CompliantRecord { get; set; }

    public virtual NonCompliantRecord? NonCompliantRecord { get; set; }

    public virtual Photo Photo { get; set; } = null!;
}
