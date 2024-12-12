using Newtonsoft.Json;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class Parecer
    {

        [JsonIgnore]
        public int idParecer { get; set; }

        [JsonProperty("id_formulario")]
        public int idFormulario { get; set; }

        [JsonProperty("parecer")]
        public String parecer {  get; set; }

        [JsonProperty("origem")]
        public String origem { get; set; }

    }
}
