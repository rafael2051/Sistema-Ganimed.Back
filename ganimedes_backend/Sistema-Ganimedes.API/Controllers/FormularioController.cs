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

        [HttpGet("/getForm/{NUSP}")]
        public IActionResult GetFormulario(string NUSP)
        {

            // USER_TYPE: "Aluno" | "Docente" | "CCP"
            // NUSP_ORIENTADOR: @NUSP
            // NUSP_CCP: @NUSP


            if(!_formularioService.ValidaNUsp(NUSP))
            {
                return StatusCode(404, "Número USP inválido.");
            }

            Formulario formulario = _formularioService.GetFormulario(NUSP);

            return StatusCode(200, "0k!");

        }

        [HttpGet("/getFormsMetaData/{NUSP}")]
        public IActionResult GetFormularios(string NUSP)
        {
            return StatusCode(200, "Ok!");
        }


    }
}
