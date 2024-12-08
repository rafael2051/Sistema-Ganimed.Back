using Microsoft.AspNetCore.Mvc;
using Sistema_Ganimedes.Application.Services;

namespace Sistema_Ganimedes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioService formularioService_;

    }
}
