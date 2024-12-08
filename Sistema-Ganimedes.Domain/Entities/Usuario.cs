using Sistema_Ganimedes.Domain.Enums;
using System.Text.Json.Serialization;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class Usuario
    {
        [JsonPropertyName("nusp")]
        public string nUsp { get; set; }

        [JsonPropertyName("nome")]
        public string nome { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("link_lattes")]
        public string linkLattes { get; set; }

        [JsonPropertyName("dt_atualizacao_lattes")]
        public DateTime dtAtualizacaoLattes { get; set; }

        [JsonPropertyName("perfil")]
        public TipoUsuario tipoUsuario { get; set; }
    }
}