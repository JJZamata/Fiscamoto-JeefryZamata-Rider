using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Fiscamoto_JeefryZamata.Infrastructure.Data.Context;
using Fiscamoto_JeefryZamata.Domain.Ports.Dependencies;
using Fiscamoto_JeefryZamata.Infrastructure.Adapters.Repositories.UnitOfWork;
using Fiscamoto_JeefryZamata.Application.Services;
using Fiscamoto_JeefryZamata.Infrastructure.Adapters.Services;

namespace Fiscamoto_JeefryZamata.Infrastructure.Configuration;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Database connection
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
            )
        );

        // ServicesRegister - Unit of Work pattern
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // CurrentUserService
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        // Business Services (se agregarán en etapas posteriores)
        // services.AddScoped<IAuthService, AuthService>();
        // services.AddScoped<ITicketService, TicketService>();

        return services;
    }
}