using MediatR;
using Microsoft.AspNetCore.Mvc;
using Fiscamoto_JeefryZamata.Application.DtoResponse;
using Fiscamoto_JeefryZamata.Application.UseCases.UserUseCase.Queries;

namespace Fiscamoto_JeefryZamata.Controllers;

[ApiController]
[Route("api/[controller]")]
// NOTA: [Authorize] se agregará en ETAPA_08 después de configurar JWT
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Obtiene todos los usuarios (PÚBLICO para testing en esta etapa)
    /// </summary>
    /// <param name="isActive">Filtro por estado activo (opcional)</param>
    /// <param name="roleId">Filtro por rol (opcional)</param>
    /// <returns>Lista de usuarios</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAllUsers(
        [FromQuery] bool? isActive = null,
        [FromQuery] int? roleId = null)
    {
        try
        {
            var query = new GetAllUsersQuery
            {
                IsActive = isActive,
                RoleId = roleId
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message, timestamp = DateTime.UtcNow });
        }
    }

    /// <summary>
    /// Obtiene un usuario específico por ID (PÚBLICO para testing en esta etapa)
    /// </summary>
    /// <param name="id">ID del usuario</param>
    /// <returns>Usuario encontrado</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDto>> GetUserById(int id)
    {
        try
        {
            var query = new GetUserByIdQuery
            {
                UserId = id
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message, timestamp = DateTime.UtcNow });
        }
    }

    /// <summary>
    /// Crea un nuevo usuario (PÚBLICO para testing en esta etapa)
    /// </summary>
    /// <param name="request">Datos del usuario a crear</param>
    /// <returns>Usuario creado</returns>
    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> CreateUser([FromBody] UserCreateRequestDto request)
    {
        try
        {
            // NOTA: Este sería un CreateUserCommand y Handler que necesitaríamos crear
            // Por ahora devolvemos un placeholder hasta tener todos los UseCases necesarios
            return Ok(new { message = $"Create user '{request.Username}' - To be implemented with CreateUserCommand", timestamp = DateTime.UtcNow });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message, timestamp = DateTime.UtcNow });
        }
    }
}