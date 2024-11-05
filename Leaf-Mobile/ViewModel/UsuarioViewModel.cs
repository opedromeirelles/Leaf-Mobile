using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf_Mobile.Model;
using Leaf_Mobile.Services;

namespace Leaf_Mobile.ViewModel
{
	public class UsuarioViewModel
	{
		private readonly UsuarioServices _usuarioServices;
		private int _idUsuario;

		public int Id
		{
			get => _idUsuario;
			set
			{
				_idUsuario = value;
			}
		}

		public UsuarioViewModel(UsuarioServices usuarioServices)
		{
			_usuarioServices = usuarioServices;
		}

		public ErrorViewModel Validarlogin(string login, string senha)
		{
			if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(senha))
			{
				try
				{
					Usuario usuario = _usuarioServices.ValidarUsuario(login, senha);

					if (usuario.IdUsuario != 0)
					{
						this.Id = usuario.IdUsuario;

						// Salva o status do login e as informações do usuário
						Preferences.Set("UserLoggedIn", true);
						Preferences.Set("NomeUsuario", usuario.Nome);

						return new ErrorViewModel(true, "Usuário autenticado.");
					}
					else
					{
						return new ErrorViewModel(false, "Usuário inválido.");
					}

				}
				catch (Exception ex)
				{

					return new ErrorViewModel(false, "Erro ao validar usuário.", ex.Message);
				}
			}
			else
			{
				return new ErrorViewModel(false, "Os campos estão vazios, preencha e tente novamente.");
			}
		}


	}
}
