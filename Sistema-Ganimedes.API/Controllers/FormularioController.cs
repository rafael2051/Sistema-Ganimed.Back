using Microsoft.AspNetCore.Mvc;
using Sistema_Ganimedes.Application.Services;
using USP.Ganimedes.API.Model;

namespace Sistema_Ganimedes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormularioController : ControllerBase
    {
        private IFormularioService _formularioService;

        public FormularioController(IFormularioService formularioService)
        {
            _formularioService = formularioService;
        }

        [HttpGet("/getFormulario/{NUSP}")]
        public IActionResult GetFormulario(string NUSP)
        {

            if(!_formularioService.ValidaNUsp(NUSP))
            {
                return StatusCode(404, "Número USP inválido.");
            }

            Formulario formulario = _formularioService.GetFormulario(NUSP);

            return StatusCode(200, "0k!");

        }


    }
}
