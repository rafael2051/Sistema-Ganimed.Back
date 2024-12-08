using Sistema_Ganimedes.Application.Interfaces;
using Sistema_Ganimedes.Domain.Entities;
using Sistema_Ganimedes.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Ganimedes.Application.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void RegisterStudent(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public bool RegisterUser(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool UsuarioExists(string nUsp)
        {
            Usuario? usuario = _usuarioRepository.GetUsuario(nUsp);

            if (usuario is not null)
            {
                return true;
            }

            return false;

        }
    }
}
