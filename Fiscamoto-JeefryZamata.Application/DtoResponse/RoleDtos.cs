namespace Fiscamoto_JeefryZamata.Application.DtoResponse;

// DTO para crear rol
public class RoleCreateRequestDto
{
    public string RoleName { get; set; } = null!;
    public string? Description { get; set; }
}

// DTO para actualizar rol
public class RoleUpdateRequestDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;
    public string? Description { get; set; }
}

// DTO para respuesta de rol
public class RoleResponseDto
{
    public int Id { get; set; }
    public string RoleName { get; set; } = null!;
    public string? Description { get; set; }
}