using Microsoft.AspNetCore.Mvc;
using Carter;

namespace Api.Funcionalidades.Usuario;

[Route("api/[controller]")]
[ApiController]
public class UsuarioEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/CrearUsuarios", ([FromServices] IUsuarioServices usuarioServices, UsuarioCommandDto usuarioDto) =>
        {
            usuarioServices.CreateUser(usuarioDto);
            return Results.Created($"/usuarios/{usuarioDto.Email}", usuarioDto);
        });


        app.MapGet("/ObtenerUsuarios/{id:int}", ([FromServices] IUsuarioServices usuarioServices, int id) =>
        {
            var usuario = usuarioServices.GetUser(id);
            if (usuario == null) return Results.NotFound($"Usuario con Id {id} no encontrado.");
            return Results.Ok(usuario);
        });


        app.MapGet("/verusuarios", ([FromServices] IUsuarioServices usuarioServices) =>
        {
            var usuarios = usuarioServices.GetUser();
            return Results.Ok(usuarios);
        });


        app.MapPut("/ModificarUsuarios/{id:int}", (IUsuarioServices usuarioServices, int id, UsuarioCommandDto usuarioDto) =>
        {
            usuarioServices.UpdateUser(id, usuarioDto);
            return Results.Ok($"Usuario con Id {id} actualizado.");
        });


        app.MapDelete("/EliminarUsuarios/{id:int}", (IUsuarioServices usuarioServices, int id) =>
        {
            usuarioServices.DeleteUser(id);
            return Results.NoContent();
        });
    }
}

