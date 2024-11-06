using Leaf_Mobile.Data;
using Leaf_Mobile.Model;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace Leaf.Repository.Pedidos
{
    public class PedidoRepository
    {
        private readonly DbConnectionManager _dbConnectionManager;

        public PedidoRepository(DbConnectionManager dbConnectionManager)
        {
            _dbConnectionManager = dbConnectionManager;
        }

        //Mapear Pedido
        public Pedido MapearPedido(SqlDataReader reader)
        {
            return new Pedido
            {
                IdPedido = reader["idpedido"] != DBNull.Value ? Convert.ToInt32(reader["idpedido"]) : 0,
                IdEntregador = reader["id_entregador"] != DBNull.Value ? Convert.ToInt32(reader["id_entregador"]) : 0,
                IdVendedor = reader["id_vendedor"] != DBNull.Value ? Convert.ToInt32(reader["id_vendedor"]) : 0,
                IdPessoa = reader["id_pessoa"] != DBNull.Value ? Convert.ToInt32(reader["id_pessoa"]) : 0,

                ValorToal = reader["valor_total"] != DBNull.Value ? Convert.ToDecimal(reader["valor_total"]) : 0m,

                EndEntrega = reader["end_entrega"] != DBNull.Value ? reader["end_entrega"].ToString() : "Não Informado",
                Cep = reader["cep"] != DBNull.Value ? reader["cep"].ToString() : "Não Informado",
                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : "Indefinido",

                DtaEmissao = reader["dta_emissao"] != DBNull.Value ? Convert.ToDateTime(reader["dta_emissao"]) : (DateTime?)null,
                DtaSaida = reader["dta_saida"] != DBNull.Value ? Convert.ToDateTime(reader["dta_saida"]) : (DateTime?)null,
                DtaEntrega = reader["dta_entrega"] != DBNull.Value ? Convert.ToDateTime(reader["dta_entrega"]) : (DateTime?)null,
                DtaCancelamento = reader["dta_cancelamento"] != DBNull.Value ? Convert.ToDateTime(reader["dta_cancelamento"]) : (DateTime?)null
            };

        }


        //Ler Pedidos
        public async Task<List<Pedido>> GetPedidosAsync()
        {
            string sql = @"select * from pedido where status = 'RT' ";

            List<Pedido> pedidos = new List<Pedido>();


            using (SqlConnection conn = _dbConnectionManager.GetConnection())
            {
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                try
                {
                    while (await reader.ReadAsync())
                    {
                        pedidos.Add(MapearPedido(reader));
                    }

                    return pedidos.Any() ? pedidos : new List<Pedido>();

                }
                catch (SqlException ex)
                {

                    throw new Exception("Erro ao listar pedido, erro: " + ex.Message);
                }
            }
        }

        public async Task<Pedido> GetPedidoAsync(int idPedido)
        {
            string sql = @"select * from pedido where idpedido = @idPedido";

            Pedido pedido = new Pedido();

            using (SqlConnection conn = _dbConnectionManager.GetConnection())
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@idPedido", idPedido);

                try
                {
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        pedido = MapearPedido(reader);
                    }

                    return pedido;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao listar pedido, erro: " + ex.Message);
                }
            }
        }

		//Atualizar pedido para baixado
		public bool AlterarStatusPedido(int idPedido, int idEntregador)
		{
			string sql = @"update pedido
                           set status = @status,
                           id_entregador = @idEntregador,
                           dta_entrega = @dtaEntrega
                           where idpedido = @idPedido";

			using (SqlConnection conn = _dbConnectionManager.GetConnection())
			{
				SqlCommand command = new SqlCommand(sql, conn);

				command.Parameters.AddWithValue("@idPedido", idPedido);
				command.Parameters.AddWithValue("@idEntregador", idEntregador);
				command.Parameters.AddWithValue("@status", "BX");
				command.Parameters.AddWithValue("@dtaEntrega", DateTime.Now);


				try
				{
					int linhasafetadas = command.ExecuteNonQuery();
					if (linhasafetadas > 0)
					{
						return true;
					}

					return false;

				}
				catch (SqlException ex)
				{
					throw new Exception("Erro ao atualizar status do pedido, erro: " + ex.Message);
				}

			}

		}


	}
}
