using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Entidades;
namespace Api.Migraciones;
public class AplicacionDbContext:DbContext
{
    public AplicacionDbContext(DbContextOptions<AplicacionDbContext> opciones)
        : base(opciones)
    {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<UsuarioRol> UsuarioRols { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<UsuarioRol>()
             .HasKey(ur => ur.IdUsuarioRol);
        
        modelBuilder.Entity<UsuarioRol>()
             .HasOne(ur => ur.Usuario)
             .WithMany(u => u.UsuarioRoles)
             .HasForeignKey(ur => ur.Usuario.IdUsuario);
        modelBuilder.Entity<UsuarioRol>()    
             .HasOne(ur => ur.Rol)
             .WithMany(r => r.UsuarioRoles)
             .HasForeignKey(ur => ur.Rol.IdRol);
    }
}
