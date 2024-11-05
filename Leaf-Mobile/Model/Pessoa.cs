using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf_Mobile.Model
{
	public class Pessoa
	{
		public int IdPessoa { get; set; }

		public string? Nome { get; set; }

		public string? Tipo { get; set; }

		public string? Cpf { get; set; }

		public string? Cnpj { get; set; }

		public string? Telefone1 { get; set; }

		public string? Telefone2 { get; set; }

		public string? Email1 { get; set; }

		public string? Email2 { get; set; }
	}
}
