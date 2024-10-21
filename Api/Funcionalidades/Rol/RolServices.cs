using Entidades;
using Api.Migraciones;

namespace Api.Funcionalidades.Rol;

public interface IRolServices
{
    void CreateRol(RolCommandDto rolDto);
    void UpdateRol(int IdRol, RolCommandDto rolDto);
    void DeleteRol(int IdRol);
    List<RolQueryDto> GetRol();
    RolQueryDto GetRol(int IdRol);

}
public class RolServices : IRolServices
{
    private readonly AplicacionDbContext context;

    public RolServices(AplicacionDbContext context)
    {
        this.context = context;
    }


    public void CreateRol(RolCommandDto rolDto)
    {
        var nuevoRol = new Entidades.Rol
        {
            Nombre = rolDto.Nombre,
            Estado = rolDto.Estado,
            FechaCreacion = rolDto.FechaCreacion
        };

        context.Rols.Add(nuevoRol);
        context.SaveChanges();
    }


    public void UpdateRol(int IdRol, RolCommandDto rolDto)
    {
        var rolExistente = context.Rols.FirstOrDefault(r => r.IdRol == IdRol);
        if (rolExistente == null)
        {
            throw new KeyNotFoundException($"Rol con Id {IdRol} no encontrado.");
        }


        if (!string.IsNullOrEmpty(rolDto.Nombre) && rolDto.Nombre != rolExistente.Nombre)
        {
            throw new InvalidOperationException("No se permite modificar el nombre del rol.");
        }
        rolExistente.Estado = rolDto.Estado;
        context.SaveChanges();
    }


    public void DeleteRol(int IdRol)
    {
        var rolExistente = context.Rols.Find(IdRol);
        if (rolExistente == null)
        {
            throw new KeyNotFoundException($"Rol con Id {IdRol} no encontrado.");
        }

        context.Rols.Remove(rolExistente);
        context.SaveChanges();
    }


    public List<RolQueryDto> GetRol()
    {
        return context.Rols.Select(r => new RolQueryDto
        {
            IdRol = r.IdRol,
            Nombre = r.Nombre,
            Estado = r.Estado,
            FechaCreacion = r.FechaCreacion
        }).ToList();
    }


    public RolQueryDto GetRol(int IdRol)
    {
        var rolExistente = context.Rols.Find(IdRol);
        if (rolExistente == null)
        {
            throw new KeyNotFoundException($"Rol con Id {IdRol} no encontrado.");
        }

        return new RolQueryDto
        {
            IdRol = rolExistente.IdRol,
            Nombre = rolExistente.Nombre,
            Estado = rolExistente.Estado,
            FechaCreacion = rolExistente.FechaCreacion
        };
    }



}
