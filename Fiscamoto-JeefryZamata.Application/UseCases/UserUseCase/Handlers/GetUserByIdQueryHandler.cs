using MediatR;
using Fiscamoto_JeefryZamata.Application.DtoResponse;
using Fiscamoto_JeefryZamata.Application.Services;
using Fiscamoto_JeefryZamata.Domain.Ports.Dependencies;
using Fiscamoto_JeefryZamata.Domain.Entities;
using Fiscamoto_JeefryZamata.Application.UseCases.UserUseCase.Queries;

namespace Fiscamoto_JeefryZamata.Application.UseCases.UserUseCase.Handlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<UserResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Repository<User>().GetById(request.UserId);

        if (user == null)
        {
            throw new Exception("Usuario no encontrado");
        }

        // Obtener rol del usuario
        var userRoles = await _unitOfWork.Repository<UserRole>().GetAll();
        var userRole = userRoles.FirstOrDefault(ur => ur.UserId == user.Id);

        var role = userRole != null ? await _unitOfWork.Repository<Role>().GetById(userRole.RoleId) : null;

        return new UserResponseDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            IsActive = user.IsActive ?? false,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            RoleName = role?.Name
        };
    }
}