using System.Text.Json.Serialization;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class Aluno
    {
        [JsonPropertyName("nusp")]
        public string nUsp { get; set; }

        [JsonPropertyName("curso")]
        public string curso { get; set; }

        [JsonPropertyName("ano_ingresso")]
        public int anoIngresso { get; set; }

        [JsonPropertyName("exame_proficiencia")]
        public String exameProficiencia { get; set; }

        [JsonPropertyName("exame_qualificacao")]
        public String exameQualificacao { get; set; }

        [JsonPropertyName("prazo_maximo_qualificacao")]
        public DateTime prazoMaximoQualificacao { get; set; }

        [JsonPropertyName("prazo_maximo_deposito_tese")]
        public DateTime prazoMaximoDepositoTese { get; set; }

        [JsonPropertyName("orientador")]
        public String orientador { get; set; }

        [JsonPropertyName("rg")]
        public String rg { get; set; }

        [JsonPropertyName("dt_nascimento")]
        public DateTime dataNascimento { get; set; }

        [JsonPropertyName("nacionalidade")]
        public String nacionalidade { get; set; }

    }
}
