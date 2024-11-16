using USP.Ganimedes.API.Model;

namespace Sistema_Ganimedes.Infrastructure.Repository
{
    internal interface IFormularioRepository
    {
        public ICollection<Formulario> GetFormularios();
        public Formulario? GetFormulario();
        public void PostFormulario(Formulario formulario);
        public void UpdateFormulario(Formulario formulario);
    }
}