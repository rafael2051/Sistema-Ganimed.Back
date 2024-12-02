using Sistema_Ganimedes.Domain.Entities;
using Sistema_Ganimedes.Domain.Enums;
using Sistema_Ganimedes.Infrastructure.Interfaces;
using Sistema_Ganimedes.Infrastructure.Repository;
using USP.Ganimedes.API.Model;

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

            if (usuario!.tipo_usuario != TipoUsuario.ALUNO) return false;

            return true;

        }

        public Formulario? GetFormulario(string nUsp)
        {

            return _formularioRepository.GetFormulario(nUsp);
        }

    }
}
