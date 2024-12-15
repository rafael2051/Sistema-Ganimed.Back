using Newtonsoft.Json;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class FormMetaData
    {
        [JsonProperty("id_formulario")]
        public int idFormulario { get; set; }

        [JsonProperty("nusp_aluno")]
        public String nUspAluno { get; set; }

        [JsonProperty("nome_aluno")]
        public String nomeAluno { get; set; }

        [JsonProperty("parecer_dado")]
        public bool parecerDado { get; set; }

    }
}
