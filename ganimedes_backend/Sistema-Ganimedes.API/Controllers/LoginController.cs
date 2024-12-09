using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_Ganimedes.Domain.Entities;
using System.Text.Json.Nodes;

namespace Sistema_Ganimedes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        [HttpPost("/login")]
        public IActionResult MakeLogin(Login login)
        {

            // SE O LOGIN FOR BEM SUCEDIDO, RETORNAR UM STATUS CODE 200 COM O TOKEN,
            // DATA DE EXPIRAÇÃO E OS DADOS DO USUÁRIO

            return StatusCode(200, JsonConvert.SerializeObject(new LoginResponse()) );

            // SE ACONTECER UM ERRO INTERNO NO SERVIDOR, RETORNA STATUS CODE 500

            // SE O USUÁRIO DIGITAR LOGIN OU SENHA ERRADA, RETORNA STATUS CODE 400

        }

    }
}
