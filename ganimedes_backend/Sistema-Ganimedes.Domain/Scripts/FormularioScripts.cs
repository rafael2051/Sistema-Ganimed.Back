using USP.Ganimedes.API.Model;

namespace Sistema_Ganimedes.Domain.Scripts
{
    public static class FormularioScripts
    {
        public static string GetFormulario()
        {
            return $@"select * from ganimedes.formulario where nusp_aluno=@nUsp";
        }

        public static string InsertFormulario()
        {
            return $@"INSERT INTO ganimedes.formulario(nusp_aluno, nusp_orientador, resultado, referencia, artigos_em_escrita, artigos_em_avaliacao, artigos_aceitos,
                    atividades_academicas, atividades_pesquisa, declaracao_adicional_comissao,
                    dificuldade_apoio_coordenacao, data_preenchimento)
	                VALUES (@aluno, @orientador, @resultado, @referencia, @artigosEmEscrita, @artigosEmAvaliacao, @artigosAceitos, @atividadesAcademicas, @atividadesPesquisa, 
                    @declaracaoAdicionalComissao, @dificuldadeApoioCoordenacao, @dataPreenchimento);";
        }

        public static string GetFormForTeacher()
        {
            return $@"select id_formulario as idFormulario,
                        nusp_aluno as aluno,
                        nusp_orientador as orientador,
                        resultado,
                        referencia,
                        artigos_em_escrita as artigosEmEscrita,
                        artigos_em_avaliacao as artigosEmAvaliacao,
                        artigos_aceitos as artigosAceitos,
                        atividades_academicas as atividadesAcademicas,
                        atividades_pesquisa as atividadesPesquisa,
                        declaracao_adicional_comissao as declaracaoAdicionalComissao,
                        dificuldade_apoio_coordenacao as dificuldadeApoioCoordenacao,
                        data_preenchimento as dataPreenchimento
                        from ganimedes.formulario
	                    where nusp_aluno = @nUspFromStudent
	                    and nusp_orientador = @nUspFromTeacher;";
        }

        public static string GetFormForStudent()
        {
            return $@"select id_formulario as idFormulario,
                        nusp_aluno as aluno,
                        nusp_orientador as orientador,
                        resultado,
                        referencia,
                        artigos_em_escrita as artigosEmEscrita,
                        artigos_em_avaliacao as artigosEmAvaliacao,
                        artigos_aceitos as artigosAceitos,
                        atividades_academicas as atividadesAcademicas,
                        atividades_pesquisa as atividadesPesquisa,
                        declaracao_adicional_comissao as declaracaoAdicionalComissao,
                        dificuldade_apoio_coordenacao as dificuldadeApoioCoordenacao,
                        data_preenchimento as dataPreenchimento
                        from ganimedes.formulario
	                    where nusp_aluno = @nUspFromStudent;";
        }

    }
}
