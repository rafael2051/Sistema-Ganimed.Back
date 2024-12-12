using Sistema_Ganimedes.Domain.Entities;
using USP.Ganimedes.API.Model;

namespace Sistema_Ganimedes.Application.Services
{
    public interface IFormularioService
    {
        public bool ValidaNUsp(string nUsp);

        public Formulario? GetFormulario(String nUspFromStudent);
        public Formulario? GetFormulario(String nUspFromTeacher, String nUspFromStudent);
        public Formulario? GetFormularioById(int idFormulario);
        public Formulario? GetFormularioByNuspAluno(int nUspFromStudent);
        public bool InsertFormulario(Formulario formulario);
        public IEnumerable<FormMetaData> GetFormsMetadata(String nUspFromTeacher);
        public IEnumerable<FormMetaData> GetFormsMetadataForCcp(String nUspFromCcpUser);
        public bool UpdateForm(Formulario formulario);

    }
}
