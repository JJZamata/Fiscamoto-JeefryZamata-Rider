namespace Fiscamoto_JeefryZamata.Application.DtoResponse;

// DTO para crear empresa
public class CompanyCreateRequestDto
{
    public string Ruc { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? ContactPerson { get; set; }
}

// DTO para actualizar empresa
public class CompanyUpdateRequestDto
{
    public string Ruc { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? ContactPerson { get; set; }
    public bool? IsActive { get; set; }
}

// DTO para respuesta de empresa
public class CompanyResponseDto
{
    public string Ruc { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? ContactPerson { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    // Campo adicional - conteo de vehículos asociados
    public int VehicleCount { get; set; }
    // ❌ SIN relaciones navegacionales complejas
}