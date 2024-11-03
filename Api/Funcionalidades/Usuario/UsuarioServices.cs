using Api.Migraciones;

namespace Api.Funcionalidades.Usuario;

public interface IUsuarioServices
{
    Task CreateUser(UsuarioCommandDto usuarioDto);
    Task UpdateUser(int IdRol,UsuarioCommandDto usuarioDto);
    Task DeleteUser(int IdRol);
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
    public async Task CreateUser(UsuarioCommandDto usuarioDto)
    {
        var usuario = new Entidades.Usuario
            {
                Nombre=usuarioDto.Nombre,
                Email = usuarioDto.Email,
                Pass = usuarioDto.Pass,
            };

            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();
        
    }

        // Actualizar usuario
        public async Task UpdateUser(int IdUsuario, UsuarioCommandDto usuarioDto)
        {
            var usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == IdUsuario);
            if (usuario != null)
            {
                usuario.Nombre=usuarioDto.Nombre;
                usuario.Email = usuarioDto.Email;
                usuario.Pass = usuarioDto.Pass;

                context.Usuarios.Update(usuario);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Usuario con Id {IdUsuario} no encontrado");
            }
        }

        public async Task DeleteUser(int IdUsuario)
        {
            var usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == IdUsuario);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Usuario con Id {IdUsuario} no encontrado");
            }
        }

      
        public List<Entidades.Usuario> GetUser()
        {
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
