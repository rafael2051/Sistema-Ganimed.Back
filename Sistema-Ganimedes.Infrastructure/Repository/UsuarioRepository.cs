using Sistema_Ganimedes.Domain.Entities;
using Sistema_Ganimedes.Infrastructure.Common.Persistence;
using Sistema_Ganimedes.Infrastructure.Interfaces;
using Dapper;
using Sistema_Ganimedes.Domain.Scripts;

namespace Sistema_Ganimedes.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContext _dbContext;

        public UsuarioRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Usuario? GetUsuario(string nUsp)
        {

            var connection = _dbContext.GetConnection();

            var script = UsuarioScripts.GetUsuario(nUsp);

            var usuario = connection.QueryFirstOrDefault<Usuario>(UsuarioScripts.GetUsuario(nUsp));

            return usuario;
        }
    }
}
