using Npgsql;

namespace Sistema_Ganimedes.Infrastructure.Common.Persistence
{
    public class DbContext
    {
        private NpgsqlConnection _connection;
        public DbContext(string connectionString) 
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }
        public NpgsqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
