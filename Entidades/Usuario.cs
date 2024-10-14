using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades;

[Table("Usuario")]
public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdUsuario { get; set; }
    [Required]
    [StringLength(50)]
    public string Nombre { get; set; }
    [Required]
    [StringLength(50)]
    public string Email { get; set; } 
    [Required]
    [StringLength(50)]
    public string Pass { get; set; } 
    [Required]
    public bool Estado{ get; set; }
    [Required]
    public DateTime FechaCreacion { get; set; }
    public List<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();
}