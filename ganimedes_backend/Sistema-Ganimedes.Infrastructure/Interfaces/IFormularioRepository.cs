using USP.Ganimedes.API.Model;

namespace Sistema_Ganimedes.Infrastructure.Repository
{
    public interface IFormularioRepository
    {
        public ICollection<Formulario> GetFormularios();
        public Formulario? GetFormulario(String nUsp);
        public void PostFormulario(Formulario formulario);
        public void UpdateFormulario(Formulario formulario);
    }
}