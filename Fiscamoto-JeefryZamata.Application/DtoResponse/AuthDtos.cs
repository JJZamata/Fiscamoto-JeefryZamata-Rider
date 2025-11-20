namespace Fiscamoto_JeefryZamata.Application.DtoResponse;

// DTO para registro de usuario
public class SignupRequestDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Email { get; set; }
    public int RoleId { get; set; }
}

// DTO para login
public class LoginRequestDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

// DTO para respuesta de autenticación
public class AuthResponseDto
{
    public string Token { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Role { get; set; } = null!;
    public int UserId { get; set; }
}