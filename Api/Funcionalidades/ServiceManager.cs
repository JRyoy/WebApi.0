using Api.Funcionalidades.Rol;
using Api.Funcionalidades.Usuario;
using Api.Funcionalidades.UsuarioRol;

namespace Api.Migraciones.ServiceManager;
public static class ServiceManager
{
    public static IServiceCollection AddServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IRolServices, RolServices>();
        services.AddScoped<IUsuarioServices, Usuarioservices>();
        services.AddScoped<IUsuarioRolServices, UsuarioRolServices>();
        
        return services;
    }
}