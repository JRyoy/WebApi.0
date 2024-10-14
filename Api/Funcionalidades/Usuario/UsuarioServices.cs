using Api.Migraciones;

namespace Api.Funcionalidades.Usuario;

public interface IUsuarioServices
{
    void CreateUser(UsuarioCommandDto usuarioDto);
    void UpdateUser(int IdRol,UsuarioCommandDto usuarioDto);
    void DeleteUser(int IdRol);
    List<Entidades.Usuario> GetUser();
    UsuarioQueryDto GetUser(int IdRol);
}
public class Usuarioservices : IUsuarioServices
{
    private readonly AplicacionDbContext context;
    public Usuarioservices(AplicacionDbContext context)
    {
        this.context = context;
    }
    public void CreateUser(UsuarioCommandDto usuarioDto)
    {
        if (usuarioDto.Email != null && usuarioDto.Pass != null)
        {
            var usuario = new Entidades.Usuario
            {
                Email = usuarioDto.Email,
                Pass = usuarioDto.Pass,
                Estado = usuarioDto.Estado
            };

            context.Usuarios.Add(usuario);
            context.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("Email y contraseña son obligatorios.");
        }
    }

        // Actualizar usuario
        public void UpdateUser(int IdUsuario, UsuarioCommandDto usuarioDto)
        {
            var usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == IdUsuario);
            if (usuario != null)
            {
                usuario.Email = usuarioDto.Email;
                usuario.Pass = usuarioDto.Pass;
                usuario.Estado = usuarioDto.Estado;

                context.Usuarios.Update(usuario);
                context.SaveChanges();
            }
            else
            {
                throw new Exception($"Usuario con Id {IdUsuario} no encontrado");
            }
        }

        public void DeleteUser(int IdUsuario)
        {
            var usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == IdUsuario);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
            }
            else
            {
                throw new Exception($"Usuario con Id {IdUsuario} no encontrado");
            }
        }

      
        public List<Entidades.Usuario> GetUser()
        {
            // var usuarios = context.Usuarios
            //     .Select(u => new UsuarioQueryDto
            //     {
            //         IdUsuario = u.IdUsuario,
            //         Nombre = u.Nombre,
            //         Email = u.Email,
            //         Pass = u.Pass,
            //         Estado = u.Estado
            //     }).ToList();

            var usuarios = context.Usuarios.ToList();
            return usuarios;
        }

       
        public UsuarioQueryDto GetUser(int IdUsuario)
        {
            var usuario = context.Usuarios
                .Where(u => u.IdUsuario == IdUsuario)
                .Select(u => new UsuarioQueryDto
                {
                    IdUsuario = u.IdUsuario,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Pass = u.Pass,
                    Estado = u.Estado
                }).FirstOrDefault();

            if (usuario == null)
            {
                throw new Exception($"Usuario con Id {IdUsuario} no encontrado");
            }

            return usuario;
        }
    }
