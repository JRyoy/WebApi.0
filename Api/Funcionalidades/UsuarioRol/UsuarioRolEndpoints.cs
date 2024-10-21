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
        app.MapPost("/AsignarRol", async ([FromServices] IUsuarioRolServices usuarioRolServices, UsuarioRolCommandDto usuarioRolDto) =>
        {
            usuarioRolServices.AsignarRol(usuarioRolDto);
            return Results.Ok("Rol/asignado exitosamente.");
        });

        app.MapDelete("/EliminarRolUsuario/{idUsuario:int}/{idRol:int}",  ([FromServices] IUsuarioRolServices usuarioRolServices, int idUsuario, int idRol) =>
        {
            usuarioRolServices.DeleteRoldelUsuario(idUsuario, idRol);
            return Results.Ok("Rol eliminado exitosamente del usuario.");
        });

        app.MapGet("VerRolesdelUsuario/{idUsuario:int}", ([FromServices] IUsuarioRolServices usuarioRolServices, int idUsuario) =>
        {
            var roles = usuarioRolServices.GetRolesdelUsuario(idUsuario);
            return Results.Ok(roles);
        });
    }
}

    




