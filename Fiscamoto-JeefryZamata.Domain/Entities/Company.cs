using System;
using System.Collections.Generic;

namespace Fiscamoto_JeefryZamata.Domain.Entities;

public partial class Company
{
    /// <summary>
    /// RUC de la empresa
    /// </summary>
    public string Ruc { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    /// <summary>
    /// fecha_emision
    /// </summary>
    public DateOnly RegistrationDate { get; set; }

    /// <summary>
    /// fecha_vencimiento
    /// </summary>
    public DateOnly ExpirationDate { get; set; }

    /// <summary>
    /// estado_ruc
    /// </summary>
    public string RucStatus { get; set; } = null!;

    /// <summary>
    /// fecha_actualizacion_ruc
    /// </summary>
    public DateOnly? RucUpdateDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<NonCompliantRecord> NonCompliantRecords { get; set; } = new List<NonCompliantRecord>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
