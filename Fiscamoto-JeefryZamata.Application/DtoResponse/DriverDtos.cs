namespace Fiscamoto_JeefryZamata.Application.DtoResponse;

// DTO para crear conductor
public class DriverCreateRequestDto
{
    public string Dni { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
}

// DTO para actualizar conductor
public class DriverUpdateRequestDto
{
    public string Dni { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool? IsActive { get; set; }
}

// DTO para respuesta de conductor
public class DriverResponseDto
{
    public string Dni { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    // Campo adicional calculado
    public string FullName => $"{FirstName} {LastName}";
    public int Age => DateTime.Today.Year - BirthDate.Year;

    // ❌ SIN relaciones navegacionales complejas
}