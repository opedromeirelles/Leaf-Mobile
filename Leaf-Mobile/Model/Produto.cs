using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf_Mobile.Model
{
	public class Produto
	{
		public int IdProduto { get; set; }
		public string? Descricao { get; set; }
		public decimal? ValorUnitario { get; set; }
		public int? QtdeEstoque { get; set; }
		public int? Status { get; set; }
	}
}
