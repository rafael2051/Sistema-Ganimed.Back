using Sistema_Ganimedes.Domain.Entities;
using Sistema_Ganimedes.Infrastructure.Interfaces;
using Sistema_Ganimedes.Infrastructure.Repository;

namespace Sistema_Ganimedes.Application.Services
{
    public class FormularioService : IFormularioService
    {
        private readonly IFormularioRepository _formularioRepository;
        private IUsuarioRepository _usuarioRepository;
        
        public FormularioService(IFormularioRepository formularioRepository,
                                 IUsuarioRepository usuarioRepository)
        {
            _formularioRepository = formularioRepository;
            _usuarioRepository = usuarioRepository;
        }

        public bool ValidaNUsp(string nUsp)
        {

            Usuario? usuario = _usuarioRepository.GetUsuario(nUsp);

            if(usuario is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
