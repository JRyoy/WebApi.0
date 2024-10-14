using Microsoft.AspNetCore.Mvc;
using Carter;
using Api.Funcionalidades.Usuario;
using static Api.Funcionalidades.UsuarioRol.UsuarioRolDto;

namespace Api.Funcionalidades.UsuarioRol;
[ApiController]
[Route("api/[controller]")]

public class UsuarioRolEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Asignar Rol", async (IUsuarioRolServices usuarioRolServices, UsuarioRolCommandDto usuarioRolDto) =>
        {
            usuarioRolServices.AsignarRol(usuarioRolDto);
            return Results.Ok("Rol asignado exitosamente.");
        });

        app.MapDelete("/Eliminar Rol de Un Usuario/{idUsuario:int}/{idRol:int}", async (IUsuarioRolServices usuarioRolServices, int idUsuario, int idRol) =>
        {
            usuarioRolServices.DeleteRoldelUsuario(idUsuario, idRol);
            return Results.Ok("Rol eliminado exitosamente del usuario.");
        });

        app.MapGet("Ver Roles del Usuario/{idUsuario:int}", async (IUsuarioRolServices usuarioRolServices, int idUsuario) =>
        {
            var roles = usuarioRolServices.GetRolesdelUsuario(idUsuario);
            return Results.Ok(roles);
        });
    }
}

    




