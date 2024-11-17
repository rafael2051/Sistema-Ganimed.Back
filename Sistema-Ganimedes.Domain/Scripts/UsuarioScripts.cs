namespace Sistema_Ganimedes.Domain.Scripts
{
    public static class UsuarioScripts
    {
        public static string GetUsuario(string nUsp)
        {
            return $@"select * from Usuario
	                where nusp='{nUsp}';";
        }
    }
}