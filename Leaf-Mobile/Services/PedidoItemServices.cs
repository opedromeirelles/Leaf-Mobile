using Leaf.Repository.Pedidos;
using Leaf_Mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf_Mobile.Services
{
	public class PedidoItemServices
	{
		private readonly PedidoItemRepository _pedidoItemRepository;

        public PedidoItemServices(PedidoItemRepository pedidoItemRepository)
        {
            _pedidoItemRepository = pedidoItemRepository;
        }


        //GET Itens pedidos de um pedido
        public async Task<List<PedidoItem>> GetPedidoItems(int idPedido)
        {
            List<PedidoItem> pedidoItems = new List<PedidoItem>();

			if (idPedido != 0)
            {
				pedidoItems = await _pedidoItemRepository.GetItensPedidoAsync(idPedido);
            }

            return pedidoItems.Any() ? pedidoItems : new List<PedidoItem>();
        }
    }
}
