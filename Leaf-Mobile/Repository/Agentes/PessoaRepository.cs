using Leaf_Mobile.Data;
using Leaf_Mobile.Model;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace Leaf.Repository.Agentes
{
	public class PessoaRepository
	{
		private readonly DbConnectionManager _dbConnectionManager;

		public PessoaRepository(DbConnectionManager dbConnectionManager)
		{
			_dbConnectionManager = dbConnectionManager;
		}

		// MÉTODO PARA MAPEAR PESSOA
		public Pessoa MapearPessoa(SqlDataReader reader)
		{
			return new Pessoa
			{
				IdPessoa = reader["idpessoa"] != DBNull.Value ? Convert.ToInt32(reader["idpessoa"]) : 0,
				Nome = reader["nome"] != DBNull.Value ? reader["nome"].ToString() : string.Empty,
				Tipo = reader["tipo"] != DBNull.Value ? reader["tipo"].ToString() : string.Empty,
				Cpf = reader["cpf"] != DBNull.Value ? reader["cpf"].ToString() : string.Empty,
				Cnpj = reader["cnpj"] != DBNull.Value ? reader["cnpj"].ToString() : string.Empty,
				Telefone1 = reader["telefone1"] != DBNull.Value ? reader["telefone1"].ToString() : string.Empty,
				Telefone2 = reader["telefone2"] != DBNull.Value ? reader["telefone2"].ToString() : string.Empty,
				Email1 = reader["email1"] != DBNull.Value ? reader["email1"].ToString() : string.Empty,
				Email2 = reader["email2"] != DBNull.Value ? reader["email2"].ToString() : string.Empty
			};

		}


		public Pessoa GetPessoaById(int idPessoa)
		{
			string sql = @"SELECT * FROM pessoa WHERE idpessoa = @idpessoa";
			Pessoa pessoa = new Pessoa();

			using (SqlConnection conn = _dbConnectionManager.GetConnection())
			{

				SqlCommand command = new SqlCommand(sql, conn);
				command.Parameters.AddWithValue("@idpessoa", idPessoa);

				SqlDataReader reader = command.ExecuteReader();

				if (reader.Read())
				{
					pessoa = MapearPessoa(reader);
				}
			}

			return pessoa ?? new Pessoa();

		}


	}
}
