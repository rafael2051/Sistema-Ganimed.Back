namespace Sistema_Ganimedes.Domain.Scripts
{
    public class ParecerScripts
    {

        public static string InsertParecer()
        {
            return $@"INSERT INTO ganimedes.parecer(id_formulario, parecer, origem, nusp_autor_parecer, conceito)
	                    VALUES (@idFormulario, @parecer, @origem, @nUspAutorParecer, @conceito);";
        }

        public static string GetParecer()
        {
            return $@"SELECT id_parecer as idParecer, 
                        id_formulario as idFormulario,
                        parecer as parecer,
                        origem as origem
	                  FROM ganimedes.parecer
                      WHERE id_formulario = @idFormulario
                      AND origem = @origem;";
        }

        public static string UpdateParecer()
        {
            return $@"UPDATE ganimedes.parecer
	                    SET id_formulario = @idFormulario, parecer = @parecer, origem = @origem
	                  WHERE id_parecer = @idParecer;";
        }

    }
}
