using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class TrackingStatus
{
    public int Id { get; set; }

    /// <summary>
    /// Indica si el tracking de ubicaciones está activo
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// ID del administrador que actualizó el estado
    /// </summary>
    public int? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }
}
