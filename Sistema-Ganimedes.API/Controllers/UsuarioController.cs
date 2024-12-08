using Microsoft.AspNetCore.Mvc;
using Sistema_Ganimedes.Application.Interfaces;
using Sistema_Ganimedes.Domain.Entities;
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
            catch (Exception ex) 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

            if (!registered)
                return StatusCode((int)HttpStatusCode.InternalServerError, "Usuário não pôde ser cadastrado por erro desconhecido");

            return StatusCode((int)HttpStatusCode.Created, "Usuário cadastrado com sucesso");
        }

        [HttpPost("/registerStudent")]
        public IActionResult RegisterStudent(Aluno aluno)
        {
            if (!_usuarioService.ChecaSeUsuarioExiste(aluno.nUsp))
                return StatusCode((int)HttpStatusCode.Conflict, "Ainda não existe registro de usuário para este aluno");

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

            return StatusCode((int)HttpStatusCode.Created, "Usuário cadastrado com sucesso");

        }

    }
}
