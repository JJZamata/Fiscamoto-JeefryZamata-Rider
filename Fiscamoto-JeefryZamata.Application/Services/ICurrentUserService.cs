namespace Fiscamoto_JeefryZamata.Application.Services;

public interface ICurrentUserService
{
    int? GetUserId();
    string? GetUsername();
    string? GetRole();
    bool IsAuthenticated();
}