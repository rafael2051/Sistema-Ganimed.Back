using Sistema_Ganimedes.Domain.Enums;
using Newtonsoft.Json;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class Usuario
    {
        [JsonProperty("nusp")]
        public string nUsp { get; set; }

        [JsonProperty("nome")]
        public string nome { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("senha")]
        public string password { get; set; }

        [JsonProperty("link_lattes")]
        public string linkLattes { get; set; }

        [JsonProperty("dt_atualizacao_lattes")]
        public DateTime dtAtualizacaoLattes { get; set; }

        [JsonProperty("perfil")]
        public String perfil { get; set; }
    }
}