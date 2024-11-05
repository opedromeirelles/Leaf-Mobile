using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf_Mobile.ViewModel
{
	public class ErrorViewModel
	{
        public bool Sucesso { get; set; }
        public string? Mensagem { get; set; }
        public string? Detalhes { get; set; }

        public ErrorViewModel(bool sucesso, string mensagem)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
        }

        public ErrorViewModel(bool sucesso, string mensagem, string detalhes)
        {
			this.Sucesso = sucesso;
			this.Mensagem = mensagem;
            this.Detalhes = detalhes;

		}

        public string ErroFormatado(ErrorViewModel error)
        {
            string erroFormatado = string.Empty;

            if (!string.IsNullOrEmpty(error.Mensagem))
            {
                erroFormatado += error.Mensagem;

			}

			if (!string.IsNullOrEmpty(error.Detalhes))
			{
				erroFormatado += " Detalhes:" + error.Mensagem;

			}

            return erroFormatado;
		}

    }
}
