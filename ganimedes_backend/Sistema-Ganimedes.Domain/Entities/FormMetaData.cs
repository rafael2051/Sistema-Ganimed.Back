using Newtonsoft.Json;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class FormMetaData
    {
        [JsonProperty("id_formulario")]
        public String idFormulario { get; set; }

        [JsonProperty("nusp_aluno")]
        public String nUspAluno { get; set; }

        [JsonProperty("nome")]
        public String nome { get; set; }

    }
}
