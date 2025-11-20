using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class ControlRecord
{
    public int Id { get; set; }

    /// <summary>
    /// Cinturón de seguridad
    /// </summary>
    public bool Seatbelt { get; set; }

    /// <summary>
    /// Estado de limpieza del vehículo
    /// </summary>
    public bool Cleanliness { get; set; }

    /// <summary>
    /// Estado de los neumáticos
    /// </summary>
    public bool Tires { get; set; }

    /// <summary>
    /// Presencia de botiquín
    /// </summary>
    public bool FirstAidKit { get; set; }

    /// <summary>
    /// Presencia de extintor
    /// </summary>
    public bool FireExtinguisher { get; set; }

    /// <summary>
    /// Estado de las luces
    /// </summary>
    public bool Lights { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<CompliantRecord> CompliantRecords { get; set; } = new List<CompliantRecord>();

    public virtual ICollection<NonCompliantRecord> NonCompliantRecords { get; set; } = new List<NonCompliantRecord>();
}
