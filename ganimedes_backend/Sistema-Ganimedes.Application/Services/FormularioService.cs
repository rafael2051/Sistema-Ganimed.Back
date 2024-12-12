using Npgsql;
using Sistema_Ganimedes.Domain.Entities;
using Sistema_Ganimedes.Infrastructure.Interfaces;
using Sistema_Ganimedes.Infrastructure.Repository;
using USP.Ganimedes.API.Model;

namespace Sistema_Ganimedes.Application.Services
{
    public class FormularioService : IFormularioService
    {
        private readonly IFormularioRepository _formularioRepository;
        private IUsuarioRepository _usuarioRepository;
        
        public FormularioService(IFormularioRepository formularioRepository,
                                 IUsuarioRepository usuarioRepository)
        {
            _formularioRepository = formularioRepository;
            _usuarioRepository = usuarioRepository;
        }

        public bool ValidaNUsp(string nUsp)
        {

            Usuario? usuario = _usuarioRepository.GetUsuario(nUsp);

            if(usuario is not null)
            {
                return true;
            }

            if (usuario!.perfil != "ALUNO") return false;

            return true;

        }

        public Formulario? GetFormulario(String nUspFromStudent)
        {

            return _formularioRepository.GetFormulario(nUspFromStudent);
        }

        public Formulario? GetFormulario(String nUspFromTeacher, String nUspFromStudent)
        {
            return _formularioRepository.GetFormulario(nUspFromTeacher, nUspFromStudent);
        }

        public Formulario? GetFormularioById(int idFormulario)
        {
            return _formularioRepository.GetFormularioById(idFormulario);
        }

        public Formulario? GetFormularioByNuspAluno(int nUspFromStudent)
        {
            return _formularioRepository.GetFormularioByNuspAluno(nUspFromStudent);
        }

        public bool InsertFormulario(Formulario formulario)
        {
            try
            {
                var rowsAffected = _formularioRepository.InsertFormulario(formulario);

                return rowsAffected > 0;

            }
            catch(NpgsqlException)
            {
                throw;
            }
        }

        public IEnumerable<FormMetaData> GetFormsMetadata(String nUspFromTeacher)
        {
            return _formularioRepository.GetFormsMetadataRelatedToTeacher(nUspFromTeacher);
        }

        public IEnumerable<FormMetaData> GetFormsMetadataForCcp(String nUspFromCcpUser)
        {
            return _formularioRepository.GetFormsMetadataRelatedToCcp(nUspFromCcpUser);
        }

        public bool UpdateForm(Formulario formulario)
        {
            var rowsAffected = _formularioRepository.UpdateForm(formulario);

            return rowsAffected > 0;

        }


    }
}
