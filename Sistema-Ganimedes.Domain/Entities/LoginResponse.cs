using System.Text.Json.Serialization;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class LoginResponse
    {

        [JsonPropertyName("token")]
        public String token {  get; set; }

        [JsonPropertyName("expiration_date")]
        public DateTime dataExpiracao { get; set; }

        [JsonPropertyName("user_data")]
        public Usuario dadosUsuario { get; set; }

        [JsonPropertyName("student_data")]
        public Aluno dadosAluno { get; set; }

    }
}
