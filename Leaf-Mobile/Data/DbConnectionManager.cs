using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Data;


namespace Leaf_Mobile.Data
{
	public class DbConnectionManager
	{
		private readonly string _connectionString;

        public DbConnectionManager(IConfiguration configuration)
        {
			
			// Ler a conexão do arquivo de configuração (.json)
			_connectionString = configuration.GetConnectionString("DefaultConnection")
							  ?? throw new ArgumentNullException(nameof(_connectionString), "A string de conexão não pode ser nula.");

		}

		//Metodo para abrir conexao
		public SqlConnection GetConnection()
		{
			var connection = new SqlConnection(_connectionString);
			connection.Open();
			return connection;
		}


	}
}
