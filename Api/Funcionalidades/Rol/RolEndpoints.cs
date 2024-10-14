using Carter;
using Microsoft.AspNetCore.Mvc;
namespace Api.Funcionalidades.Rol;

[Route("api/[controller]")]
[ApiController]
public class RolEndpoints :ICarterModule
{
   public void AddRoutes(IEndpointRouteBuilder app)
    {
         
        app.MapGet("/api/roles", async ([FromServices] IRolServices rolServices) =>
        {
            var roles = rolServices.GetRol();
            return Results.Ok(roles);
        }).WithName("VerRoles");

        
        app.MapGet("/api/roles/{idRol}", ([FromServices] IRolServices rolServices, int idRol) =>
        {
            var rol = rolServices.GetRol(idRol);
            return Results.Ok(rol);
        }).WithName("Buscar Rol por id");

        
        app.MapPost("/api/roles", ([FromServices] IRolServices rolServices, [FromBody] RolCommandDto rolDto) =>
        {
            rolServices.CreateRol(rolDto);
            return Results.Ok("Rol creado exitosamente");
        }).WithName("Crear Rol");

        
        app.MapPut("/api/roles/{idRol}", ([FromServices] IRolServices rolServices, int idRol, [FromBody] RolCommandDto rolDto) =>
        {
            rolServices.UpdateRol(idRol, rolDto);
            return Results.Ok("Rol actualizado exitosamente");
        }).WithName("Modificar Rol");

        
        app.MapDelete("/api/roles/{idRol}", ([FromServices] IRolServices rolServices, int idRol) =>
        {
            rolServices.DeleteRol(idRol);
            return Results.Ok("Rol eliminado exitosamente");
        }).WithName("Eliminar Rol");
    }
}
