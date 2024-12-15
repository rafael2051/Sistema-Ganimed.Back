using Newtonsoft.Json;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class Aluno
    {
        [JsonProperty("nusp")]
        public string nUsp { get; set; }

        [JsonProperty("curso")]
        public string curso { get; set; }

        [JsonProperty("ano_ingresso")]
        public int anoIngresso { get; set; }

        [JsonProperty("exame_proficiencia")]
        public String exameProficiencia { get; set; }

        [JsonProperty("exame_qualificacao")]
        public String exameQualificacao { get; set; }

        [JsonProperty("prazo_maximo_qualificacao")]
        public DateTime prazoMaximoQualificacao { get; set; }

        [JsonProperty("prazo_maximo_deposito_tese")]
        public DateTime prazoMaximoDepositoTese { get; set; }

        [JsonProperty("orientador")]
        public String orientador { get; set; }

        [JsonProperty("rg")]
        public String rg { get; set; }

        [JsonProperty("dt_nascimento")]
        public DateTime dtNascimento { get; set; }

        [JsonProperty("nacionalidade")]
        public String nacionalidade { get; set; }

    }
}
