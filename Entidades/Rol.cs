using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades;

[Table("Rol")]
public class Rol
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdRol { get; set; }
    [Required]
    [StringLength(50)]
    public string? Nombre { get; set; } 
    [Required]
    public bool Estado { get; set; }
    [Required]
    public DateTime FechaCreacion { get; set; }
    public List<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();
}
