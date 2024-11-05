using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.Repository.Pedidos;
using Leaf_Mobile.Model;

namespace Leaf_Mobile.Services
{

	public class PedidoServices
	{
		private readonly PedidoRepository _pedidoRepository;

		public PedidoServices(PedidoRepository pedidoRepository)
		{
			_pedidoRepository = pedidoRepository;
		}

		//GET Pedidos
		public async Task<List<Pedido>> GetPedidos()
		{
			try
			{
				List<Pedido> pedidos = await _pedidoRepository.GetPedidosAsync();
				return pedidos.Any() ? pedidos : new List<Pedido>();
			}
			catch (Exception ex)
			{

				throw new Exception("Erro ao listar pedidos. " + ex.Message);
			}
		}

		public async Task<Pedido> GetPedido(int idPedido)
		{
			try
			{
				Pedido pedido = new Pedido();
				
				if (idPedido != 0)
				{
					pedido = await _pedidoRepository.GetPedidoAsync(idPedido);
				}

				return pedido ?? new Pedido();
			}
			catch (Exception ex)
			{

				throw new Exception("Erro ao consultar pedido. " + ex.Message);
			}
		}

		public bool AtulizarStatusPedido(int idEntregador, int idPedido)
		{
			if (idEntregador != 0 && idPedido != 0)
			{
				try
				{
					return _pedidoRepository.AlterarStatusPedido(idPedido, idEntregador);
				}

				catch (Exception ex)
				{

					throw new Exception("Não foi possivel baixar o pedido. " + ex.Message);
				}
			}

			return false;
		}
	}
}
