using Sistema_Ganimedes.Domain.Entities;

namespace Sistema_Ganimedes.Application.Interfaces
{
    public interface IUsuarioService
    {

        public bool UsuarioExists(string nUsp);
        public bool RegisterUser(Usuario usuario);
        public void RegisterStudent(Aluno aluno);

    }
}
