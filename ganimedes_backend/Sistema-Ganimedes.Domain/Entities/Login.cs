using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class Login
    {
        [JsonPropertyName("username")]
        public String usuario {  get; set; }

        [JsonPropertyName("password")]
        public String password { get; set; }

    }
}
