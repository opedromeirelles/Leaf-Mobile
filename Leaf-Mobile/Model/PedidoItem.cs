using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf_Mobile.Model
{
	public sealed class PedidoItem
	{
		public int IdItemPedido { get; set; }
		public int IdProduto { get; set; }
		public int Quantidade { get; set; }
		public decimal SubTotal { get; set; }
		public int IdPedido { get; set; }

		public Produto? Produto { get; set; }
		public List<Produto>? Produtos { get; set; }
	}
}
