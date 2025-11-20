using MediatR;
using Microsoft.AspNetCore.Mvc;
using Fiscamoto_JeefryZamata.Application.DtoResponse;
using Fiscamoto_JeefryZamata.Application.UseCases.AuthUseCase.Commands;

namespace Fiscamoto_JeefryZamata.Controllers;

[ApiController]
[Route("api/[controller]")]
// NOTA: [Authorize] se agregará en ETAPA_08 después de configurar JWT
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Registra un nuevo usuario (PÚBLICO para testing en esta etapa)
    /// </summary>
    /// <param name="request">Datos de registro</param>
    /// <returns>Usuario creado con token</returns>
    [HttpPost("signup")]
    public async Task<ActionResult<AuthResponseDto>> Signup([FromBody] SignupRequestDto request)
    {
        try
        {
            var command = new SignupCommand
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                RoleId = request.RoleId
            };

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Login), new { }, result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message, timestamp = DateTime.UtcNow });
        }
    }

    /// <summary>
    /// Inicia sesión de usuario (PÚBLICO para testing en esta etapa)
    /// </summary>
    /// <param name="request">Credenciales de login</param>
    /// <returns>Token de autenticación</returns>
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginRequestDto request)
    {
        try
        {
            var command = new LoginCommand
            {
                Username = request.Username,
                Password = request.Password
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message, timestamp = DateTime.UtcNow });
        }
    }
}