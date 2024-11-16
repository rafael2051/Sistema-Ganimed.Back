using Sistema_Ganimedes.Infrastructure.Common.Persistence;
using Dapper;
using USP.Ganimedes.API.Model;
using Sistema_Ganimedes.Infrastructure.Interfaces;

namespace Sistema_Ganimedes.Infrastructure.Repository
{
    public class FormularioRepository : IFormularioRepository
    {
        private DbContext? _dbContext;

        public Formulario GetFormulario()
        {
            var connection = _dbContext?.GetConnection();
            connection?.Open();


            connection?.Close();

            return null;

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
