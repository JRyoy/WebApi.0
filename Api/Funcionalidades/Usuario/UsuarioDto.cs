namespace Api.Funcionalidades.Usuario;
public class UsuarioCommandDto
{
    public string Nombre { get; set; }
    public string Email { get; set; } 
    public string Pass { get; set; } 
    public bool Estado{ get; set; }
}
public class UsuarioQueryDto
{
    public int IdUsuario { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; } 
    public string Pass { get; set; } 
    public bool Estado{ get; set; }
}