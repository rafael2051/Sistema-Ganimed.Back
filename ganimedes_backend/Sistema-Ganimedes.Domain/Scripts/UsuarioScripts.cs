namespace Sistema_Ganimedes.Domain.Scripts
{
    public static class UsuarioScripts
    {

        public static string CreateUsuario()
        {
            return $@"INSERT INTO ganimedes.usuario(nusp, nome, email, password, link_lattes, dt_atualizacao_lattes, perfil)
	                VALUES (@nUsp, @nome, @email, @password, @linkLattes,
	                @dtAtualizacaoLattes, @perfil);";
        }

        public static string CreateAluno()
        {
            return $@"INSERT INTO ganimedes.aluno(
	                nusp, curso, ano_ingresso, exame_proficiencia, exame_qualificacao, prazo_maximo_qualificacao, prazo_maximo_deposito_tese, orientador, rg, dt_nascimento, nacionalidade)
	                VALUES (@nUsp, @curso, @anoIngresso, @exameProficiencia, @exameQualificacao, @prazoMaximoQualificacao, @prazoMaximoDepositoTese, @orientador, @rg, @dataNascimento, @nacionalidade);";
        }

        public static string GetUsuario(string nUsp)
        {
            return $@"select * from ganimedes.usuario
	                where nusp='{nUsp}';";
        }

        public static string GetAluno(string nUsp)
        {
            return $@"select * from ganimedes.aluno 
	                    where nusp='{nUsp}';";
        }

    }
}