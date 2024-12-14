using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Sistema_Ganimedes.Application.Services;
using System.Net;
using USP.Ganimedes.API.Model;
using Sistema_Ganimedes.Application.Interfaces;
using Newtonsoft.Json;
using Sistema_Ganimedes.Domain.Entities;

namespace Sistema_Ganimedes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormularioController : ControllerBase
    {
        private IFormularioService _formularioService;
        private IAuthenticationService _authenticationService;
        private IUsuarioService _usuarioService;

        public FormularioController(IFormularioService formularioService, IAuthenticationService authenticationService,
                                        IUsuarioService usuarioService)
        {
            _formularioService = formularioService;
            _authenticationService = authenticationService;
            _usuarioService = usuarioService;
        }

        [HttpGet("/getForm/{nUsp}")]
        public async Task<IActionResult> GetFormulario(string nUsp)
        {

            Request.Headers.TryGetValue("Authorization", out StringValues authenticationValue);
            Request.Headers.TryGetValue("Nusp", out StringValues nUspFromTeacher);

            string nUspFromSender;
            String? nUspFromStudent = nUsp;
            bool requestMadeByTeacher = false;
            bool requestMadeByCcp = false;

            if (authenticationValue.Count() == 0)
                return StatusCode((int)HttpStatusCode.Unauthorized, "É necessário fornecer um token de autenticação para acessar esse recurso");

            string token = authenticationValue.ToString();

            Usuario? usuario = _usuarioService.GetDadosUsuario(nUsp);

            if (usuario is null)
                return StatusCode((int)HttpStatusCode.NotFound, "O número usp fornecido na url não está cadastrado no banco");

            if (usuario.perfil != "ALUNO")
                return StatusCode((int)HttpStatusCode.BadRequest, "Forneca o número USP de um aluno na url");

            if (nUspFromTeacher.Count() > 0)
            {
                nUspFromSender = nUspFromTeacher.ToString();
                Usuario? docente = _usuarioService.GetDadosUsuario(nUspFromSender);

                if (docente is null)
                    return StatusCode((int)HttpStatusCode.NotFound, "Docente não cadastrado no banco");

                if (docente.perfil == "ALUNO")
                    return StatusCode((int)HttpStatusCode.Unauthorized, "Apenas docentes/ccp podem acessar esse recurso");

                if(docente.perfil == "DOCENTE")
                    requestMadeByTeacher = true;

                if(docente.perfil == "CCP")
                    requestMadeByCcp = true;

            }
            else
                nUspFromSender = nUsp;


            if (!await _authenticationService.ValidarToken(token, nUspFromSender))
                return StatusCode((int)HttpStatusCode.Unauthorized, "Token inválido");

            Formulario? formulario;

            if (requestMadeByCcp)
                formulario = _formularioService.GetFormulario(nUspFromStudent);
            if (requestMadeByTeacher)
                formulario = _formularioService.GetFormulario(nUspFromSender, nUspFromStudent);
            else
                formulario = _formularioService.GetFormulario(nUspFromStudent);
    

            return StatusCode((int)HttpStatusCode.Accepted, JsonConvert.SerializeObject(formulario));

        }

        [HttpGet("/getFormsMetaData")]
        public async Task<IActionResult> GetFormularios()
        {
            //Verificar se token foi enviado como header na request
            Request.Headers.TryGetValue("Authorization", out StringValues authenticationValue);
            Request.Headers.TryGetValue("Nusp", out StringValues nUspValue);

            if (authenticationValue.Count() == 0 || nUspValue.Count == 0)
                return StatusCode((int)HttpStatusCode.Unauthorized, "É necessário fornecer um token de autenticação para acessar esse recurso");

            string token = authenticationValue.ToString();
            string nUsp = nUspValue.ToString();

            //Verificar se número usp enviado é de um docente
            Usuario? usuario = _usuarioService.GetDadosUsuario(nUsp);

            if (usuario is null)
                return StatusCode((int)HttpStatusCode.NotFound, "O número usp fornecido na url não está cadastrado no banco");

            if (usuario.perfil == "ALUNO")
                return StatusCode((int)HttpStatusCode.BadRequest, "Forneca o número USP de um docente/ccp na url");

            //Autenticar número USP
            if (!await _authenticationService.ValidarToken(token, nUsp))
                return StatusCode((int)HttpStatusCode.Unauthorized, "Token inválido");

            IEnumerable<FormMetaData> formsMetaData;

            if(usuario.perfil == "DOCENTE")
                formsMetaData = _formularioService.GetFormsMetadata(nUsp);
            else
                formsMetaData = _formularioService.GetFormsMetadataForCcp(nUsp);

            return StatusCode((int)HttpStatusCode.OK, JsonConvert.SerializeObject(formsMetaData));


        }

        [HttpPost("/postFormulario")]
        public async Task<IActionResult> PostFormulario(Formulario formulario)
        {

            Request.Headers.TryGetValue("Authorization", out StringValues authenticationValue);

            if (authenticationValue.Count() == 0)
                return StatusCode((int)HttpStatusCode.Unauthorized, "É necessário fornecer um token de autenticação para acessar esse recurso");

            string token = authenticationValue.ToString();

            if (!await _authenticationService.ValidarToken(token, formulario.aluno))
                return StatusCode((int)HttpStatusCode.Unauthorized, "Token inválido");



            try 
            {

                if (_formularioService.GetFormulario(formulario.aluno) is not null)
                    return StatusCode((int)HttpStatusCode.Locked, "Já foi inserido formulário para esse aluno");

                bool formWasInserted = _formularioService.InsertFormulario(formulario);

                if (!formWasInserted)
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Formulário não foi armazenado no banco de dados por motivo desconhecido");

                return StatusCode((int)HttpStatusCode.Created, "Formulário armazenado no banco de dados");


            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut("/updateFormulario")]
        public async Task<IActionResult> UpdateFormulario(Formulario formulario)
        {

            Request.Headers.TryGetValue("Authentication", out StringValues authenticationValue);

            if (authenticationValue.Count() == 0)
                return StatusCode((int)HttpStatusCode.Unauthorized, "É necessário fornecer um token de autenticação para acessar esse recurso");

            string token = authenticationValue.ToString();

            if (!await _authenticationService.ValidarToken(token, formulario.aluno))
                return StatusCode((int)HttpStatusCode.Unauthorized, "Token inválido");


            try
            {
                bool formWasUpdated = _formularioService.UpdateForm(formulario);

                if (!formWasUpdated)
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Formulário não foi atualizado por motivo desconhecido");

                return StatusCode((int)HttpStatusCode.OK, "Formulário foi atualizado");

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }


    }
}
