
using System.Collections.Generic;
using System.Linq;
using global::Api.Migraciones;
using static global::Api.Funcionalidades.UsuarioRol.UsuarioRolDto;

namespace Api.Funcionalidades.UsuarioRol;

    public interface IUsuarioRolServices
    {
        void AsignarRol(UsuarioRolCommandDto usuarioRolDto);
        List<UsuarioRolQueryDto> GetRolesdelUsuario(int idUsuario);
        void DeleteRoldelUsuario(int idUsuario, int idRol);
    }

    public class UsuarioRolServices : IUsuarioRolServices
    {
        private readonly AplicacionDbContext _context;

        public UsuarioRolServices(AplicacionDbContext context)
        {
            _context = context;
        }

    public void AsignarRol(UsuarioRolCommandDto usuarioRolDto)
    {

        var usuario = _context.Usuarios.Find(usuarioRolDto.IdUsuario);
        var rol = _context.Rols.Find(usuarioRolDto.IdRol);

        if (usuario == null)
            throw new KeyNotFoundException("Usuario no encontrado.");
        if (rol == null)
            throw new KeyNotFoundException("Rol no encontrado.");

       
        var usuarioRolExistente = _context.UsuarioRols
            .FirstOrDefault(ur => ur.IdUsuario == usuarioRolDto.IdUsuario && ur.IdRol == usuarioRolDto.IdRol);
        if (usuarioRolExistente != null)
            throw new InvalidOperationException("El rol ya está asignado a este usuario.");

        var usuarioRol = new Entidades.UsuarioRol
        {
            IdUsuario = usuarioRolDto.IdUsuario,
            IdRol = usuarioRolDto.IdRol
        };

        _context.UsuarioRols.Add(usuarioRol);
        _context.SaveChanges();
    }

    
    public List<UsuarioRolQueryDto> GetRolesdelUsuario(int idUsuario)
    {
        
        var usuario = _context.Usuarios.Find(idUsuario);
        if (usuario == null)
            throw new KeyNotFoundException("Usuario no encontrado.");

        return _context.UsuarioRols
            .Where(ur => ur.IdUsuario == idUsuario)
            .Select(ur => new UsuarioRolQueryDto
            {
                IdUsuarioRol = ur.IdUsuarioRol,
                IdUsuario = ur.IdUsuario,
                IdRol = ur.IdRol,
            }).ToList();
    }

    
    public void DeleteRoldelUsuario(int idUsuario, int idRol)
    {
        var usuarioRol = _context.UsuarioRols
            .FirstOrDefault(ur => ur.IdUsuario == idUsuario && ur.IdRol == idRol);
        if (usuarioRol == null)
            throw new KeyNotFoundException("El rol no está asignado a este usuario.");

        _context.UsuarioRols.Remove(usuarioRol);
        _context.SaveChanges();
    }

    }
