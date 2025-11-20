using FiscamotoJeefryZamata.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Registrar todos los servicios mediante el método de extensión
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fiscamoto API V1");
        c.RoutePrefix = string.Empty; // Swagger en la raíz
    });
}

app.MapControllers();

// JWT (se configurará en etapas posteriores)
app.UseAuthentication();
app.UseAuthorization();

app.Run();