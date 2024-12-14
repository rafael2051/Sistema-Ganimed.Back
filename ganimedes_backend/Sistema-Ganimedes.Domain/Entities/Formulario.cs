using Newtonsoft.Json;

namespace USP.Ganimedes.API.Model
{
    public class Formulario
    {
        [JsonProperty("id_formulario")]
        public int idFormulario { get; set; }

        [JsonProperty("aluno")]
        public string aluno { get; set; } = "";

        [JsonProperty("orientador")]
        public string orientador { get; set; } = "";

        [JsonProperty("artigos_em_escrita")]
        public int artigosEmEscrita { get; set; }

        [JsonProperty("artigos_em_avaliacao")]
        public int artigosEmAvaliacao { get; set; }

        [JsonProperty("artigos_aceitos")]
        public int artigosAceitos { get; set; }

        [JsonProperty("atividades_academicas")]
        public string atividadesAcademicas { get; set; } = "";

        [JsonProperty("atividades_pesquisa")]
        public string atividadesPesquisa { get; set; } = "";

        [JsonProperty("declaracao_adicional_comissao")]
        public string declaracaoAdicionalComissao { get; set; } = "";

        [JsonProperty("dificuldade_apoio_coordenacao")]
        public bool dificuldadeApoioCoordenacao { get; set; }

        [JsonProperty("data_preenchimento")]
        public DateTime dataPreenchimento { get; set; }
    }
}