using MediatR;
using Fiscamoto_JeefryZamata.Application.DtoResponse;
using Fiscamoto_JeefryZamata.Domain.Ports.Dependencies;
using Fiscamoto_JeefryZamata.Domain.Entities;
using Fiscamoto_JeefryZamata.Application.UseCases.AuthUseCase.Commands;
using BCrypt.Net;

namespace Fiscamoto_JeefryZamata.Application.UseCases.AuthUseCase.Handlers;

public class SignupCommandHandler : IRequestHandler<SignupCommand, AuthResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public SignupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthResponseDto> Handle(SignupCommand request, CancellationToken cancellationToken)
    {
        // Verificar si el usuario ya existe
        var existingUsers = await _unitOfWork.Repository<User>().GetAll();
        var existingUser = existingUsers.FirstOrDefault(u => u.Username == request.Username);

        if (existingUser != null)
        {
            throw new Exception("El nombre de usuario ya está en uso");
        }

        // Verificar si el rol existe
        var role = await _unitOfWork.Repository<Role>().GetById(request.RoleId);
        if (role == null)
        {
            throw new Exception("El rol especificado no existe");
        }

        // Crear nuevo usuario
        var user = new User
        {
            Id = 0, // Identity en base de datos
            Username = request.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Email = request.Email,
            IsActive = true,
            CreatedAt = DateTime.Now
        };

        // Guardar en base de datos
        await _unitOfWork.Repository<User>().Add(user);
        await _unitOfWork.Complete();

        // Obtener el ID generado
        var createdUser = (await _unitOfWork.Repository<User>().GetAll())
            .FirstOrDefault(u => u.Username == user.Username);

        if (createdUser == null)
        {
            throw new Exception("Error al crear el usuario");
        }

        // Asignar rol al usuario
        var userRole = new UserRole
        {
            UserId = createdUser.Id,
            RoleId = request.RoleId
        };

        await _unitOfWork.Repository<UserRole>().Add(userRole);
        await _unitOfWork.Complete();

        // Generar token (temporal - se implementará en ETAPA_07_JWT_ROLES.md)
        var token = "temporal_token_will_be_implemented";

        return new AuthResponseDto
        {
            Token = token,
            Username = user.Username,
            Role = role.Name,
            UserId = createdUser.Id
        };
    }
}