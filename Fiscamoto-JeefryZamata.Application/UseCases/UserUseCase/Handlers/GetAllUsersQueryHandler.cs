using MediatR;
using Fiscamoto_JeefryZamata.Application.DtoResponse;
using Fiscamoto_JeefryZamata.Application.Services;
using Fiscamoto_JeefryZamata.Domain.Ports.Dependencies;
using Fiscamoto_JeefryZamata.Domain.Entities;
using Fiscamoto_JeefryZamata.Application.UseCases.UserUseCase.Queries;

namespace Fiscamoto_JeefryZamata.Application.UseCases.UserUseCase.Handlers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<IEnumerable<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        // Obtener todos los usuarios
        var users = await _unitOfWork.Repository<User>().GetAll();
        var userRoles = await _unitOfWork.Repository<UserRole>().GetAll();
        var roles = await _unitOfWork.Repository<Role>().GetAll();

        // Aplicar filtros si se proporcionan
        if (request.IsActive.HasValue)
        {
            users = users.Where(u => u.IsActive == request.IsActive.Value);
        }

        if (request.RoleId.HasValue)
        {
            var userIdsWithRole = userRoles
                .Where(ur => ur.RoleId == request.RoleId.Value)
                .Select(ur => ur.UserId)
                .ToHashSet();

            users = users.Where(u => userIdsWithRole.Contains(u.Id));
        }

        // Transformar a DTOs con información de rol
        var userDtos = new List<UserResponseDto>();

        foreach (var user in users)
        {
            var userRole = userRoles.FirstOrDefault(ur => ur.UserId == user.Id);
            var role = userRole != null ? roles.FirstOrDefault(r => r.Id == userRole.RoleId) : null;

            userDtos.Add(new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                IsActive = user.IsActive ?? false,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                RoleName = role?.Name
            });
        }

        return userDtos;
    }
}