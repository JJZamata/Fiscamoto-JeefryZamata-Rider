using MediatR;
using Fiscamoto_JeefryZamata.Application.DtoResponse;

namespace Fiscamoto_JeefryZamata.Application.UseCases.UserUseCase.Queries;

public class GetUserByIdQuery : IRequest<UserResponseDto>
{
    public int UserId { get; set; }
}