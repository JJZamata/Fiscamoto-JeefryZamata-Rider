# Usamos una imagen base de .NET 9 SDK para el stage de compilación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# PRIMERO: Copiar los archivos .csproj para optimizar el cache de Docker
# Solo si los .csproj cambian, Docker restaurará los paquetes
COPY ["Fiscamoto-JeefryZamata/Fiscamoto-JeefryZamata.csproj", "Fiscamoto-JeefryZamata/"]
COPY ["Fiscamoto-JeefryZamata.Domain/Fiscamoto-JeefryZamata.Domain.csproj", "Fiscamoto-JeefryZamata.Domain/"]
COPY ["Fiscamoto-JeefryZamata.Application/Fiscamoto-JeefryZamata.Application.csproj", "Fiscamoto-JeefryZamata.Application/"]
COPY ["Fiscamoto-JeefryZamata.Infrastructure/Fiscamoto-JeefryZamata.Infrastructure.csproj", "Fiscamoto-JeefryZamata.Infrastructure/"]
COPY ["Fiscamoto-JeefryZamata.sln", "./"]

# Restaurar paquetes para toda la solución (optimizado por cache)
RUN dotnet restore "./Fiscamoto-JeefryZamata/Fiscamoto-JeefryZamata.csproj"

# Copiar todo el código fuente
COPY . .

# Compilar toda la solución y publicar el proyecto principal
# --self-contained true para incluir el runtime
# --runtime linux-x64 para el runtime de Linux compatible con Render
RUN dotnet publish "./Fiscamoto-JeefryZamata/Fiscamoto-JeefryZamata.csproj" \
    -c Release \
    -o /app/out \
    --self-contained true \
    --runtime linux-x64


# Stage final: Imagen ligera con .NET 9 runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Variables de entorno para Render
# Render inyectará el valor de PORT automáticamente
ENV ASPNETCORE_URLS=http://0.0.0.0:$PORT

# Copiar los archivos publicados desde el stage de compilación
COPY --from=build /app/out .

# Exponer el puerto que usa Render
# Render usa la variable $PORT para mapear dinámicamente
EXPOSE $PORT

# Punto de entrada: Ejecutar la DLL principal de la aplicación
ENTRYPOINT ["dotnet", "Fiscamoto-JeefryZamata.dll"]