using Newtonsoft.Json;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class Login
    {
        [JsonProperty("username")]
        public String username {  get; set; }

        [JsonProperty("password")]
        public String password { get; set; }

        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
