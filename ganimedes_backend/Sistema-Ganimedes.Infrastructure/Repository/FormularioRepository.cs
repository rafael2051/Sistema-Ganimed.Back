using Sistema_Ganimedes.Infrastructure.Common.Persistence;
using Dapper;
using USP.Ganimedes.API.Model;
using Sistema_Ganimedes.Domain.Scripts;

namespace Sistema_Ganimedes.Infrastructure.Repository
{
    public class FormularioRepository : IFormularioRepository
    {
        private readonly DbContext _dbContext;

        public FormularioRepository(DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Formulario? GetFormulario(String nUsp)
        {
            var connection = _dbContext?.GetConnection();

            connection!.Open();

            Formulario? formulario = connection.QueryFirstOrDefault<Formulario>(FormularioScripts.GetFormulario(), new
            {
                nUsp = nUsp
            });

            connection.Close();

            return formulario;
        }

        public ICollection<Formulario> GetFormularios()
        {
            throw new NotImplementedException();
        }

        public void PostFormulario(Formulario formulario)
        {
            throw new NotImplementedException();
        }

        public void UpdateFormulario(Formulario formulario)
        {
            throw new NotImplementedException();
        }
    }
}
