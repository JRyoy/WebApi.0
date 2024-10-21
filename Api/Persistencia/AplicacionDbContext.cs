using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Entidades;
namespace Api.Migraciones;
public class AplicacionDbContext:DbContext
{
    public AplicacionDbContext(DbContextOptions<AplicacionDbContext> opciones)
        : base(opciones)
    {}

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<UsuarioRol> UsuarioRols { get; set; }
}
