using MediatR;
using Fiscamoto_JeefryZamata.Application.DtoResponse;
using Fiscamoto_JeefryZamata.Domain.Ports.Dependencies;
using Fiscamoto_JeefryZamata.Domain.Entities;
using Fiscamoto_JeefryZamata.Application.UseCases.AuthUseCase.Commands;
using BCrypt.Net;

namespace Fiscamoto_JeefryZamata.Application.UseCases.AuthUseCase.Handlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public LoginCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // Buscar usuario por username
        var users = await _unitOfWork.Repository<User>().GetAll();
        var user = users.FirstOrDefault(u => u.Username == request.Username);

        if (user == null)
        {
            throw new Exception("Credenciales inválidas");
        }

        if (!user.IsActive.HasValue || !user.IsActive.Value)
        {
            throw new Exception("Usuario inactivo");
        }

        // Verificar password
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            throw new Exception("Credenciales inválidas");
        }

        // Obtener rol del usuario
        var userRoles = await _unitOfWork.Repository<UserRole>().GetAll();
        var userRole = userRoles.FirstOrDefault(ur => ur.UserId == user.Id);

        if (userRole == null)
        {
            throw new Exception("El usuario no tiene roles asignados");
        }

        var role = await _unitOfWork.Repository<Role>().GetById(userRole.RoleId);
        if (role == null)
        {
            throw new Exception("Rol no encontrado");
        }

        // Generar token (temporal - se implementará en ETAPA_07_JWT_ROLES.md)
        var token = "temporal_token_will_be_implemented";

        return new AuthResponseDto
        {
            Token = token,
            Username = user.Username,
            Role = role.Name,
            UserId = user.Id
        };
    }
}