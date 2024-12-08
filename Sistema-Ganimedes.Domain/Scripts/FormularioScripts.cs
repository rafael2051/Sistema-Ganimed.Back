namespace Sistema_Ganimedes.Domain.Scripts
{
    public static class FormularioScripts
    {
        public static string GetFormulario()
        {
            return $@"select * from formularios where nusp=@nUsp";
        }
    }
}
