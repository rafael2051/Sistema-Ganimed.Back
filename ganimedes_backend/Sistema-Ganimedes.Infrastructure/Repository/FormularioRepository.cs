using Sistema_Ganimedes.Infrastructure.Common.Persistence;
using Dapper;
using USP.Ganimedes.API.Model;
using Sistema_Ganimedes.Domain.Scripts;
using Npgsql;
using Sistema_Ganimedes.Domain.Entities;

namespace Sistema_Ganimedes.Infrastructure.Repository
{
    public class FormularioRepository : IFormularioRepository
    {
        private readonly DbContext _dbContext;

        public FormularioRepository(DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Formulario? GetFormulario(String nUspFromStudent)
        {
            var connection = _dbContext?.GetConnection();

            Formulario? formulario = connection!.QueryFirstOrDefault<Formulario>(FormularioScripts.GetFormForStudent(), new
            {
                nUspFromStudent = nUspFromStudent
            });

            connection!.Close();

            return formulario;
        }

        public Formulario? GetFormulario(String nUspFromTeacher, String nUspFromStudent)
        {
            var connection = _dbContext?.GetConnection();

            Formulario? formulario = connection!.QueryFirstOrDefault<Formulario>(FormularioScripts.GetFormForTeacher(), new
            {
                nUspFromTeacher = nUspFromTeacher,
                nUspFromStudent = nUspFromStudent
            });

            connection!.Close();

            return formulario;
        }

        public Formulario? GetFormularioById(int idFormulario)
        {

            var connection = _dbContext?.GetConnection();

            Formulario? formulario = connection!.QueryFirstOrDefault<Formulario>(FormularioScripts.GetFormById(), new
            {
                idFormulario
            });

            connection!.Close();

            return formulario;

        }

        public Formulario? GetFormularioByNuspAluno(int nUspFromStudent)
        {
            var connection = _dbContext?.GetConnection();

            Formulario? formulario = connection!.QueryFirstOrDefault<Formulario>(FormularioScripts.GetFormByNuspAluno(), new
            {
                nUspFromStudent = nUspFromStudent
            });

            connection!.Close();

            return formulario;
        }

        public ICollection<Formulario> GetFormularios()
        {
            throw new NotImplementedException();
        }

        public int InsertFormulario(Formulario formulario)
        {

            try
            {
                var connection = _dbContext.GetConnection();
                var rowsAffected = connection.Execute(FormularioScripts.InsertFormulario(), formulario);

                connection!.Close();

                return rowsAffected;
            }
            catch (NpgsqlException)
            {
                throw;
            }

        }

        public void UpdateFormulario(Formulario formulario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FormMetaData> GetFormsMetadataRelatedToTeacher(String nUspFromTeacher)
        {
            try
            {
                var connection = _dbContext?.GetConnection();
                
                var formsMetaData = connection!.Query<FormMetaData>(FormularioScripts.GetFormsMetadataRelatedToTeacher(),
                    new 
                    {
                        nUspFromTeacher = nUspFromTeacher
                    });

                connection!.Close();

                return formsMetaData;

            }
            catch (NpgsqlException)
            {  
                throw; 
            }
        }

        public IEnumerable<FormMetaData> GetFormsMetadataRelatedToCcp(String nUspFromCcpUser)
        {
            try
            {
                var connection = _dbContext?.GetConnection();

                var formsMetaData = connection!.Query<FormMetaData>(FormularioScripts.GetFormsMetadataRelatedToCcp());

                connection!.Close();

                return formsMetaData;

            }
            catch (NpgsqlException)
            {
                throw;
            }
        }

        public int UpdateForm(Formulario formulario)
        {
            try
            {
                var connection = _dbContext?.GetConnection();

                var rowsUpdated = connection!.Execute(FormularioScripts.UpdateForm(), formulario);

                connection!.Close();

                return rowsUpdated;

            }
            catch (NpgsqlException)
            {
                throw;
            }
        }


    }
}
