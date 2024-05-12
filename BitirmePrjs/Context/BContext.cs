using System.Data;
using System.Data.SqlClient;

namespace BitirmePrjs.Context
{
    public class BContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public BContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("sqlCon");
        }

        public IDbConnection CreateSqlConnection() => new SqlConnection(_connectionString);
    }
}
