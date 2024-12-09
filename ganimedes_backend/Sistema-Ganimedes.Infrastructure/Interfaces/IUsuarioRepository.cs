using Sistema_Ganimedes.Domain.Entities;

namespace Sistema_Ganimedes.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuario? GetUsuario(string nUsp);
        public int CadastrarUsuario(Usuario usuario);
        public int CadastrarAluno(Aluno aluno);

    }
}
