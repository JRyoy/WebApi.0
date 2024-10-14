namespace Api.Funcionalidades.Rol;
public class RolCommandDto
{
    public int IdRol { get; set; }
    public string? Nombre { get; set; } 
    public bool Estado { get; set; }
    public DateTime FechaCreacion { get; set; }
}
public class RolQueryDto
{
    public int IdRol { get; set; }
    public string? Nombre { get; set; } 
    public bool Estado { get; set; }
    public DateTime FechaCreacion { get; set; }
}