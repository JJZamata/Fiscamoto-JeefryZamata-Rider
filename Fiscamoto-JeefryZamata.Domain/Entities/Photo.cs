using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class Photo
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Coordinates { get; set; } = null!;

    public string Url { get; set; } = null!;

    public DateTime CaptureDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<RecordPhoto> RecordPhotos { get; set; } = new List<RecordPhoto>();

    public virtual User User { get; set; } = null!;
}
