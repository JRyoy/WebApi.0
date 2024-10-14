namespace Api.Funcionalidades.UsuarioRol;

public class UsuarioRolDto
{
    public class UsuarioRolCommandDto
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
    }

    public class UsuarioRolQueryDto
    {
        public int IdUsuarioRol { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
    }
}

