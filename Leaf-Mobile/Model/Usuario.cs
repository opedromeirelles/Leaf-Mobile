using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf_Mobile.Model
{
	public class Usuario
	{
		public int IdUsuario { get; set; }
		public string? Nome { get; set; }
		public string? Login { get; set; }
		public string? Senha { get; set; }

		public int Status { get; set; }
		public int IdDpto { get; set; }

		public Departamento? Departamento { get; set; }
	}
}
