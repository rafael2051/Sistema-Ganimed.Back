using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Sistema_Ganimedes.Application.Interfaces;
using Sistema_Ganimedes.Application.Services;
using Sistema_Ganimedes.Domain.Entities;
using System.Net;
using USP.Ganimedes.API.Model;

namespace Sistema_Ganimedes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParecerController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IParecerService _parecerService;
        private readonly IFormularioService _formularioService;

        public ParecerController(IUsuarioService usuarioService, IAuthenticationService authenticationService, IParecerService parecerService,
                                    IFormularioService formularioService)
        {
            _usuarioService = usuarioService;
            _authenticationService = authenticationService;
            _parecerService = parecerService;
            _formularioService = formularioService;
        }

        [HttpPost("/postParecer")]
        public async Task<IActionResult> PostParecer(Parecer parecer)
        {
            Request.Headers.TryGetValue("Authorization", out StringValues authenticationValue);
            Request.Headers.TryGetValue("Nusp", out StringValues nUspFromSender);

            if (authenticationValue.Count() == 0 || nUspFromSender.Count() == 0)
                return StatusCode((int)HttpStatusCode.Unauthorized, "É necessário fornecer um token de autenticação para acessar esse recurso");

            string token = authenticationValue.ToString();
            string nUsp = nUspFromSender.ToString();

            Usuario? usuario = _usuarioService.GetDadosUsuario(nUsp);

            if (!await _authenticationService.ValidarToken(token, nUsp))
                return StatusCode((int)HttpStatusCode.Unauthorized, "Token inválido");

            if (usuario is null)
                return StatusCode((int)HttpStatusCode.NotFound, "Não existe registro para docente/cpp no banco de dados para o número usp fornecido");

            if (usuario.perfil != "DOCENTE" && usuario.perfil != "CCP")
                return StatusCode((int)HttpStatusCode.Unauthorized, "Apenas docentes e ccp tem permissão para fazer essa operação");

            Formulario? formulario = _formularioService.GetFormularioById(parecer.idFormulario);

            if (formulario is null)
                return StatusCode((int)HttpStatusCode.NotFound, "Não existe registro de formulário para o id de formulário fornecido");

            if(usuario.perfil == "DOCENTE" && usuario.nUsp != formulario.orientador)
                return StatusCode((int)HttpStatusCode.Unauthorized, "O número usp fornecido não é o mesmo do orientador responsável pelo formulário fornecido");

            if (usuario.perfil != parecer.origem)
                return StatusCode((int)HttpStatusCode.Unauthorized, "Perfil de usuário diferente do perfil fornecido no parecer");

            if (parecer.nUspAutorParecer != nUspFromSender)
                return StatusCode((int)HttpStatusCode.BadRequest, "Números USP do header e do parecer divergentes");


            Parecer? parecerFromDb = _parecerService.GetParecer(formulario.idFormulario, parecer.origem);

            try
            {
                if (parecerFromDb is null)
                {
                    var parecerWasInserted = _parecerService.InsertParecer(parecer);
                    if (!parecerWasInserted)
                        return StatusCode((int)HttpStatusCode.InternalServerError, "Parecer não foi inserido no banco de dados por motivo desconhecido");

                    return StatusCode((int)HttpStatusCode.OK, "Parecer inserido no banco de dados");

                }
                else
                {

                    parecer.idParecer = parecerFromDb.idParecer;

                    var parecerWasUpdated = _parecerService.UpdateParecer(parecer);
                    if (!parecerWasUpdated)
                        return StatusCode((int)HttpStatusCode.InternalServerError, "Parecer não foi atualizado no banco de dados por motivo desconhecido");

                    return StatusCode((int)HttpStatusCode.OK, "Parecer atualizado no banco de dados");

                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

    }
}
