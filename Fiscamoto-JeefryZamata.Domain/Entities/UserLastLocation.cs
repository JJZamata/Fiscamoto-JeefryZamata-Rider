using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class UserLastLocation
{
    /// <summary>
    /// ID del fiscalizador (1 registro por usuario)
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

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
