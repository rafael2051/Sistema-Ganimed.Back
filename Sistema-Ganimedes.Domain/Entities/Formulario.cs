using System.Text.Json.Serialization;

namespace USP.Ganimedes.API.Model
{
    public class Formulario
    {
        [JsonPropertyName("id_parecer")]
        public int IdParecer { get; set; }

        [JsonPropertyName("aluno")]
        public string Aluno { get; set; } = "";

        [JsonPropertyName("orientador")]
        public string Orientador { get; set; } = "";

        [JsonPropertyName("resultado")]
        public int Resultado { get; set; }

        [JsonPropertyName("artigos_em_escrita")]
        public int ArtigosEmEscrita { get; set; }

        [JsonPropertyName("artigos_em_avaliacao")]
        public int ArtigosEmAvaliacao { get; set; }

        [JsonPropertyName("artigos_aceitos")]
        public int ArtigosAceitos { get; set; }

        [JsonPropertyName("atividades_academicas")]
        public string AtividadesAcademicas { get; set; } = "";

        [JsonPropertyName("atividades_pesquisa")]
        public string AtividadesPesquisa { get; set; } = "";

        [JsonPropertyName("declaracao_adicional_comissao")]
        public string DeclaracaoAdicionalComissao { get; set; } = "";

        [JsonPropertyName("dificuldade_apoio_coordenacao")]
        public bool DificuldadeApoioCoordenacao { get; set; }

        [JsonPropertyName("data_preenchimento")]
        public DateTime DataPreenchimento { get; set; }
    }
}