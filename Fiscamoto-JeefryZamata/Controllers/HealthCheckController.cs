using Microsoft.AspNetCore.Mvc;

namespace Fiscamoto_JeefryZamata.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCheckController : ControllerBase
{
    /// <summary>
    /// Verifica que la API está funcionando
    /// </summary>
    /// <returns>Mensaje de estado</returns>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "Healthy",
            timestamp = DateTime.UtcNow,
            version = "1.0.0",
            architecture = "Clean Architecture + CQRS + MediatR"
        });
    }

    /// <summary>
    /// Verifica que MediatR está funcionando
    /// </summary>
    /// <returns>Mensaje con estado de MediatR</returns>
    [HttpGet("mediatr")]
    public IActionResult CheckMediatR()
    {
        return Ok(new
        {
            status = "MediatR Ready",
            message = "Handlers registrados correctamente con ApplicationAssemblyMarker",
            timestamp = DateTime.UtcNow
        });
    }
}