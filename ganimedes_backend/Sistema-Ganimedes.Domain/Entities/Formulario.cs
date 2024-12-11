using Newtonsoft.Json;

namespace USP.Ganimedes.API.Model
{
    public class Formulario
    {
        [JsonProperty("id_parecer")]
        public int IdParecer { get; set; }

        [JsonProperty("aluno")]
        public string Aluno { get; set; } = "";

        [JsonProperty("orientador")]
        public string Orientador { get; set; } = "";

        [JsonProperty("resultado")]
        public int Resultado { get; set; }

        [JsonProperty("artigos_em_escrita")]
        public int ArtigosEmEscrita { get; set; }

        [JsonProperty("artigos_em_avaliacao")]
        public int ArtigosEmAvaliacao { get; set; }

        [JsonProperty("artigos_aceitos")]
        public int ArtigosAceitos { get; set; }

        [JsonProperty("atividades_academicas")]
        public string AtividadesAcademicas { get; set; } = "";

        [JsonProperty("atividades_pesquisa")]
        public string AtividadesPesquisa { get; set; } = "";

        [JsonProperty("declaracao_adicional_comissao")]
        public string DeclaracaoAdicionalComissao { get; set; } = "";

        [JsonProperty("dificuldade_apoio_coordenacao")]
        public bool DificuldadeApoioCoordenacao { get; set; }

        [JsonProperty("data_preenchimento")]
        public DateTime DataPreenchimento { get; set; }
    }
}