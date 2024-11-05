﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf_Mobile.Model
{
	public sealed class Pedido
	{
		public int IdPedido { get; set; }
		public string? Status { get; set; }
		public decimal? ValorToal { get; set; }
		public string? EndEntrega { get; set; }
		public string? Cep { get; set; }
		public int IdPessoa { get; set; }
		public int IdVendedor { get; set; }
		public int IdEntregador { get; set; }
		public DateTime? DtaEmissao { get; set; }
		public DateTime? DtaSaida { get; set; }
		public DateTime? DtaEntrega { get; set; }
		public DateTime? DtaCancelamento { get; set; }

		//Objetos de relacionamento:
		public Pessoa? Pessoa { get; set; }
		public Usuario? Entregador { get; set; }
		public Usuario? Vendedor { get; set; }
	}
}
