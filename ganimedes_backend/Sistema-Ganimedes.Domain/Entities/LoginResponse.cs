using System.Net;
using Newtonsoft.Json;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class LoginResponse
    {

        [JsonIgnore]
        public HttpStatusCode statusCode { get; set; }
        [JsonIgnore]
        public String nUsp { get; set; }

        [JsonProperty("token")]
        public String token {  get; set; }

        [JsonProperty("expiration_date")]
        public DateTimeOffset dataExpiracao { get; set; }

        [JsonProperty("user_data")]
        public Usuario dadosUsuario { get; set; }

        [JsonProperty("student_data")]
        public Aluno? dadosAluno { get; set; }

    }
}
