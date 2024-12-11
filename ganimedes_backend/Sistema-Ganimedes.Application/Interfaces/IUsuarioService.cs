using Sistema_Ganimedes.Domain.Entities;
using Sistema_Ganimedes.Domain.Enums;

namespace Sistema_Ganimedes.Application.Interfaces
{
    public interface IUsuarioService
    {
        public bool RegistraAluno(Aluno aluno);
        public bool RegistraUsuario(Usuario usuario);
        public bool ChecaSeUsuarioExiste(string nUsp);
        public bool ChecaSeUsuarioEDoTipoFornecido(string nUsp, String tipoUsuario);
        public Usuario? GetDadosUsuario(string nUsp);
        public Aluno? GetDadosAluno(string nUsp);

    }
}
