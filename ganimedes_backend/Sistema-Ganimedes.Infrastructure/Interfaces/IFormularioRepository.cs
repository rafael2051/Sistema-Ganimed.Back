using Sistema_Ganimedes.Domain.Entities;
using USP.Ganimedes.API.Model;

namespace Sistema_Ganimedes.Infrastructure.Repository
{
    public interface IFormularioRepository
    {
        public ICollection<Formulario> GetFormularios();
        public Formulario? GetFormulario(String nUspFromStudent);
        public Formulario? GetFormulario(String nUspFromTeacher, String nUspFromStudent);
        public Formulario? GetFormularioById(int idFormulario);
        public Formulario? GetFormularioByNuspAluno(int nUspFromStudent);
        public int InsertFormulario(Formulario formulario);
        public void UpdateFormulario(Formulario formulario);
        public IEnumerable<FormMetaData> GetFormsMetadataRelatedToTeacher(String nUspFromTeacher);
        public IEnumerable<FormMetaData> GetFormsMetadataRelatedToCcp(String nUspFromCcpUser);
        public int UpdateForm(Formulario formulario);
    }
}