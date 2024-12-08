using Sistema_Ganimedes.Domain.Entities;
using Sistema_Ganimedes.Infrastructure.Common.Persistence;
using Sistema_Ganimedes.Infrastructure.Interfaces;
using Dapper;
using Sistema_Ganimedes.Domain.Scripts;
using Npgsql;
using System.Globalization;

namespace Sistema_Ganimedes.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContext _dbContext;

        public UsuarioRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CadastrarAluno(Aluno aluno)
        {
            var connection = _dbContext.GetConnection();

            connection.Open();

            try
            {
                var rowsAffected = connection.Execute(UsuarioScripts.CreateAluno(), aluno);
                connection.Close();
                return rowsAffected;
            }
            catch (NpgsqlException)
            {
                connection.Close();
                throw;
            }
        }

        public int CadastrarUsuario(Usuario usuario)
        {
            var connection = _dbContext.GetConnection();

            try
            {
                var rowsAffected = connection.Execute(UsuarioScripts.CreateUsuario(), usuario);
                connection.Close();
                return rowsAffected;
            } catch(NpgsqlException)
            {
                connection.Close();
                throw;
            }


        }

        public Usuario? GetUsuario(string nUsp)
        {

            var connection = _dbContext.GetConnection();

            var usuario = connection.QueryFirstOrDefault<Usuario>(UsuarioScripts.GetUsuario(nUsp));

            connection!.Close();

            return usuario;
        }
    }
}
