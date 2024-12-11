using Sistema_Ganimedes.Domain.Entities;

namespace Sistema_Ganimedes.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        public int CadastrarUsuario(Usuario usuario);
        public int CadastrarAluno(Aluno aluno);
        public Usuario? GetUsuario(string nUsp);
        public Aluno? GetAluno(string nUsp);

    }
}
