using Dapper;
using Npgsql;
using Sistema_Ganimedes.Domain.Entities;
using Sistema_Ganimedes.Domain.Scripts;
using Sistema_Ganimedes.Infrastructure.Common.Persistence;

namespace Sistema_Ganimedes.Infrastructure.Repository
{
    public class ParecerRepository : IParecerRepository
    {
        private readonly DbContext _dbContext;

        public ParecerRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int InsertParecer(Parecer parecer)
        {
            try
            {
                var connection = _dbContext.GetConnection();
                var rowsAffected = connection.Execute(ParecerScripts.InsertParecer(), parecer);

                connection!.Close();

                return rowsAffected;
            }
            catch (NpgsqlException)
            {
                throw;
            }
        }

        public Parecer? GetParecer(int idFormulario, string origem)
        {

            try
            {
                var connection = _dbContext.GetConnection();
                var parecer = connection.QueryFirstOrDefault<Parecer>(ParecerScripts.GetParecer(), new 
                {
                    idFormulario = idFormulario,
                    origem = origem
                });

                connection!.Close();

                return parecer;
            }
            catch (NpgsqlException)
            {
                throw;
            }

        }

        public int UpdateParecer(Parecer parecer)
        {
            try
            {
                var connection = _dbContext.GetConnection();
                var rowsAffected = connection.Execute(ParecerScripts.UpdateParecer(), parecer);

                connection!.Close();

                return rowsAffected;
            }
            catch (NpgsqlException)
            {
                throw;
            }
        }


    }
}
