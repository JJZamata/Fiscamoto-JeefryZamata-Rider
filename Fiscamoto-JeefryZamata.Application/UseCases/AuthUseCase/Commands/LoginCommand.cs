using MediatR;
using Fiscamoto_JeefryZamata.Application.DtoResponse;

namespace Fiscamoto_JeefryZamata.Application.UseCases.AuthUseCase.Commands;

public class LoginCommand : IRequest<AuthResponseDto>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}