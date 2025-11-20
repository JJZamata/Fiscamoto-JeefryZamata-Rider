using MediatR;
using Fiscamoto_JeefryZamata.Application.DtoResponse;

namespace Fiscamoto_JeefryZamata.Application.UseCases.UserUseCase.Queries;

public class GetAllUsersQuery : IRequest<IEnumerable<UserResponseDto>>
{
    // Parámetros opcionales de filtrado
    public bool? IsActive { get; set; }
    public int? RoleId { get; set; }
}