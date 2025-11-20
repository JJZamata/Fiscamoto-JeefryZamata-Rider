namespace Fiscamoto_JeefryZamata.Application.DtoResponse;

// DTO para crear vehículo
public class VehicleCreateRequestDto
{
    public string PlateNumber { get; set; } = null!;
    public string CompanyRuc { get; set; } = null!;
    public string OwnerDni { get; set; } = null!;
    public int TypeId { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int? Year { get; set; }
    public string? Color { get; set; }
}

// DTO para actualizar vehículo
public class VehicleUpdateRequestDto
{
    public string PlateNumber { get; set; } = null!;
    public string? CompanyRuc { get; set; }
    public string? OwnerDni { get; set; }
    public int? TypeId { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int? Year { get; set; }
    public string? Color { get; set; }
    public bool? IsActive { get; set; }
}

// DTO para respuesta de vehículo
public class VehicleResponseDto
{
    public string PlateNumber { get; set; } = null!;
    public string CompanyRuc { get; set; } = null!;
    public string OwnerDni { get; set; } = null!;
    public int TypeId { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int? Year { get; set; }
    public string? Color { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    // Campos adicionales desde relaciones
    public string? CompanyName { get; set; }
    public string? OwnerName { get; set; }
    public string? VehicleTypeName { get; set; }
    // ❌ SIN relaciones navegacionales complejas
}