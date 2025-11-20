using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class UserLocationLog
{
    public int Id { get; set; }

    /// <summary>
    /// ID del fiscalizador que reportó la ubicación
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Latitud de la ubicación
    /// </summary>
    public decimal Latitude { get; set; }

    /// <summary>
    /// Longitud de la ubicación
    /// </summary>
    public decimal Longitude { get; set; }

    /// <summary>
    /// Precisión del GPS en metros
    /// </summary>
    public decimal? Accuracy { get; set; }

    /// <summary>
    /// Fecha y hora en que se capturó la ubicación
    /// </summary>
    public DateTime Timestamp { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
