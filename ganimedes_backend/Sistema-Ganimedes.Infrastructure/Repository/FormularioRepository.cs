using Sistema_Ganimedes.Infrastructure.Common.Persistence;
using Dapper;
using USP.Ganimedes.API.Model;
using Sistema_Ganimedes.Domain.Scripts;
using Npgsql;

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
    }
}
