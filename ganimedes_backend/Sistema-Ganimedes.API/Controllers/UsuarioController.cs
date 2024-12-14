using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_Ganimedes.Application.Interfaces;
using Sistema_Ganimedes.Domain.Entities;
using Sistema_Ganimedes.Domain.Enums;
using System.Net;

namespace Sistema_Ganimedes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("/ping/{str}")]
        public IActionResult Ping(String str)
        {

            Console.WriteLine(str);
            return StatusCode((int)HttpStatusCode.OK, JsonConvert.SerializeObject(new ResponseMessage(str)));
            
        }

        [HttpPost("/registerUser")]
        public IActionResult RegisterUser(Usuario usuario)
        {

            if (_usuarioService.ChecaSeUsuarioExiste(usuario.nUsp))
                return StatusCode((int)HttpStatusCode.Conflict, "Este usuário já está cadastrado");

            bool registered;

            try
            {
                registered = _usuarioService.RegistraUsuario(usuario);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex) 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

            if (!registered)
                return StatusCode((int)HttpStatusCode.InternalServerError, "Usuário não pôde ser cadastrado por erro desconhecido");

            return StatusCode((int)HttpStatusCode.OK, JsonConvert.SerializeObject(new ResponseMessage("Usuário cadastrado com sucesso!")));
        }

        [HttpPost("/registerStudent")]
        public IActionResult RegisterStudent(Aluno aluno)
        {
            if (!_usuarioService.ChecaSeUsuarioExiste(aluno.nUsp))
                return StatusCode((int)HttpStatusCode.Conflict, "Ainda não existe registro de usuário para este aluno");

            if (!_usuarioService.ChecaSeUsuarioEDoTipoFornecido(aluno.nUsp, "ALUNO"))
                return StatusCode((int)HttpStatusCode.Conflict, "O número USP fornecido não é o de um aluno");

            bool registered;

            try
            {
                registered = _usuarioService.RegistraAluno(aluno);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

            if (!registered)
                return StatusCode((int)HttpStatusCode.InternalServerError, "Aluno não pôde ser registrado por erro desconhecido");

            return StatusCode((int)HttpStatusCode.Created, JsonConvert.SerializeObject(new ResponseMessage("Usuário cadastrado com sucesso!")));

        }

    }
}
