using Sistema_Ganimedes.Domain.Entities;

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
            return $@"SELECT nusp,
                            nome,
                            email,
                            password,
                            link_lattes as linkLattes,
                            dt_atualizacao_lattes as dtAtualizacaoLattes,
                            perfil
	                    FROM ganimedes.usuario
                        WHERE nusp='{nUsp}';";
        }

        public static string GetAluno(string nUsp)
        {
            return $@"SELECT nusp, 
                            curso, 
                            ano_ingresso as anoIngresso, 
                            exame_proficiencia as exameProficiencia,
                            exame_qualificacao as exameQualificacao, 
                            prazo_maximo_qualificacao as prazoMaximoQualificacao, 
                            prazo_maximo_deposito_tese as prazoMaximoDepositoTese, 
                            orientador, 
                            rg, 
                            dt_nascimento as dtNascimento, 
                            nacionalidade
	                FROM ganimedes.aluno
                    WHERE nusp='{nUsp}';";
        }

    }
}