using Sistema_Ganimedes.Domain.Entities;
using USP.Ganimedes.API.Model;

namespace Sistema_Ganimedes.Application.Services
{
    public interface IFormularioService
    {
        public bool ValidaNUsp(string nUsp);

        public Formulario? GetFormulario(String nUspFromStudent);
        public Formulario? GetFormulario(String nUspFromTeacher, String nUspFromStudent);

        public bool InsertFormulario(Formulario formulario);
        public IEnumerable<FormMetaData> GetFormsMetadata(String nUspFromTeacher);
        public bool UpdateForm(Formulario formulario);

    }
}
