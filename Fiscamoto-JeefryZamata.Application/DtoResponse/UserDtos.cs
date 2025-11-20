namespace Fiscamoto_JeefryZamata.Application.DtoResponse;

// DTO para crear usuario (usado por administradores)
public class UserCreateRequestDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Email { get; set; }
    public bool? IsActive { get; set; } = true;
    public int? RoleId { get; set; }
}

// DTO para actualizar usuario
public class UserUpdateRequestDto
{
    public int UserId { get; set; }
    public string Username { get; set; } = null!;
    public string? Email { get; set; }
    public bool? IsActive { get; set; }
    // Password se actualiza en endpoint separado por seguridad
}

// DTO para respuesta de usuario
public class UserResponseDto
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string? Email { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Campo adicional desde la relación con Role
    public string? RoleName { get; set; }
    // ❌ SIN PasswordHash (seguridad)
    // ❌ SIN relaciones navegacionales
}