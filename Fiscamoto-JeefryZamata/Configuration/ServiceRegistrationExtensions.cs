using Microsoft.OpenApi.Models;
using Fiscamoto_JeefryZamata.Infrastructure.Configuration;
using MediatR;
using System.Reflection;

namespace FiscamotoJeefryZamata.Configuration;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();

        // Registro de servicios de Infraestructura (incluye DbContext)
        services.AddInfrastructureServices(configuration);

        // Registrar MediatR usando ApplicationAssemblyMarker
        var applicationAssembly = typeof(Fiscamoto_JeefryZamata.Application.MediatR.ApplicationAssemblyMarker).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        // Habilitar controladores
        services.AddControllers();

        // Habilitar Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Fiscamoto-JeefryZamata API - Clean Architecture + CQRS + MediatR",
                Version = "v1",
                Description = "API con Clean Architecture + CQRS + MediatR"
            });

            // Configuración de JWT en Swagger (se usará en etapas posteriores)
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Ingresa el token en el formato: Bearer {tu token}"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });

        return services;
    }
}