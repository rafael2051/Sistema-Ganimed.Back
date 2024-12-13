using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_Ganimedes.Application.Interfaces;
using Sistema_Ganimedes.Domain.Entities;
using System.Net;

using Sistema_Ganimedes.Domain.Enums;

namespace Sistema_Ganimedes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IUsuarioService _usuarioService;

        public LoginController(ILoginService loginService, IUsuarioService usuarioService)
        {
            _loginService = loginService;
            _usuarioService = usuarioService;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> MakeLogin(Login login)
        {
            try
            {
                var loginResponse = await _loginService.ValidarLogin(login.username, login.password);

                if (loginResponse.statusCode != HttpStatusCode.Accepted)
                {
                    return StatusCode((int)loginResponse.statusCode, null);
                }

                var dadosUsuario = _usuarioService.GetDadosUsuario(loginResponse.nUsp);

                if (dadosUsuario is null)
                    return StatusCode((int)HttpStatusCode.InternalServerError, JsonConvert.SerializeObject(
                            new Exception("Unknown error: the user was authenticated, but for some reason it was not possible" +
                            "to get the user data")
                        ));

                Aluno? dadosAluno = null;

                if (dadosUsuario.perfil == "ALUNO")
                    dadosAluno = _usuarioService.GetDadosAluno(loginResponse.nUsp);

                loginResponse.dadosUsuario = dadosUsuario;
                loginResponse.dadosAluno = dadosAluno;

                return StatusCode((int)loginResponse.statusCode, JsonConvert.SerializeObject(loginResponse));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, JsonConvert.SerializeObject(e));
            }

        }

    }
}
