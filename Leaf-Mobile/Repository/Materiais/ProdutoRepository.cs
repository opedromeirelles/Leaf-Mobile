using Leaf_Mobile.Data;
using Leaf_Mobile.Model;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace Leaf.Repository.Materiais
{
	public class ProdutoRepository
	{
		private readonly DbConnectionManager _dbConnectionManager;

		public ProdutoRepository(DbConnectionManager dbConnectionManager)
		{
			_dbConnectionManager = dbConnectionManager;
		}

		//MÉTODO PARA MAPEAR PRODUTO
		public Produto MapearProduto(SqlDataReader reader)
		{
			return new Produto
			{
				IdProduto = reader["idproduto"] != DBNull.Value ? Convert.ToInt32(reader["idproduto"]) : 0,
				Descricao = reader["descricao"] != DBNull.Value ? reader["descricao"].ToString() : string.Empty,
				ValorUnitario = reader["valor_unitario"] != DBNull.Value ? Convert.ToDecimal(reader["valor_unitario"]) : 0.0m,
				QtdeEstoque = reader["qtde_estoque"] != DBNull.Value ? Convert.ToInt32(reader["qtde_estoque"]) : 0,
				Status = reader["status"] != DBNull.Value ? Convert.ToInt32(reader["status"]) : 0
			};

		}


		public Produto GetProdutoById(int idProduto)
		{
			string sql = @"Select * FROM produto Where idproduto = @idproduto";
			Produto produto = new Produto();

			using (SqlConnection conn = _dbConnectionManager.GetConnection())
			{

				SqlCommand command = new SqlCommand(sql, conn);
				command.Parameters.AddWithValue("@idproduto", idProduto);

				SqlDataReader reader = command.ExecuteReader();

				if (reader.Read())
				{
					produto = MapearProduto(reader);
				}

			}

			return produto ?? new Produto();
		}

		public void AtualizarSatusProduto(int idProduto)
		{
			using (SqlConnection conn = _dbConnectionManager.GetConnection())
			{
				string sql = @"UPDATE  SET produto
                               status = @status
                               WHERE idproduto = @idproduto";

				SqlCommand command = new SqlCommand(sql, conn);
				command.Parameters.AddWithValue("@idproduto", idProduto);

				try
				{
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{

					throw new Exception($"Erro alterar o status do protudo, erro: {ex.Message}");
				}


			}
		}
	}
}
