using System.Collections.Generic;
using Leaf_Mobile.Data;
using Leaf_Mobile.Model;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace Leaf.Repository.Pedidos
{
    public class PedidoItemRepository
    {
        private readonly DbConnectionManager _dbConnectionManager;
        public PedidoItemRepository(DbConnectionManager dbConnectionManager)
        {
            _dbConnectionManager = dbConnectionManager;
        }

        public PedidoItem MapearItemPedido(SqlDataReader reader)
        {
			return new PedidoItem
			{
				IdItemPedido = reader["iditempedido"] != DBNull.Value ? Convert.ToInt32(reader["iditempedido"]) : 0,
				IdPedido = reader["id_pedido"] != DBNull.Value ? Convert.ToInt32(reader["id_pedido"]) : 0,
				IdProduto = reader["id_produto"] != DBNull.Value ? Convert.ToInt32(reader["id_produto"]) : 0,
				Quantidade = reader["qtde"] != DBNull.Value ? Convert.ToInt32(reader["qtde"]) : 0,
				SubTotal = reader["sub_total"] != DBNull.Value ? Convert.ToDecimal(reader["sub_total"]) : 0.0m
			};

		}

		//Listar item do pedido
		public async Task<List<PedidoItem>> GetItensPedidoAsync(int idPedido)
        {
            string sql = @"select * from ITEM_PEDIDO where id_pedido = @idPedido";

            using (SqlConnection conn = _dbConnectionManager.GetConnection())
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@idPedido", idPedido);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                try
                {

                    List<PedidoItem> itensPedido = new List<PedidoItem>();

                    while (await reader.ReadAsync())
                    {
                        itensPedido.Add(MapearItemPedido(reader));
                    }

                    return itensPedido;

                }
                catch (SqlException ex)
                {
                    throw new Exception("Não foi possível buscar os itens do pedido. Erro: " + ex.Message);
                }

            }
        }


    }
}
