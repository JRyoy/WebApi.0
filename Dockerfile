
# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Crear y moverse al directorio de trabajo
WORKDIR /source

# Copiar todos los archivos al contenedor y restaurar las dependencias del proyecto
COPY . ./
RUN dotnet restore

# Publicar la aplicación en modo Release en el directorio /Aplicacion
RUN dotnet publish Api -c Release -o /Aplicacion

# Etapa final: imagen base más ligera de ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /Aplicacion

# Copiar los archivos publicados desde la etapa anterior
COPY --from=build-env /Aplicacion ./

# Exponer el puerto en el que se ejecutará la aplicación
EXPOSE 5000

# Configurar la URL base de ASP.NET para que escuche en el puerto 5000
ENV ASPNETCORE_URLS="http://0.0.0.0:5000"

# Especificar el archivo DLL de entrada para ejecutar la aplicación
ENTRYPOINT ["dotnet", "Api.dll"]



