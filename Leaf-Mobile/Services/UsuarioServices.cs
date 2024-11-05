using GoogleGson;
using Leaf.Repository.Agentes;
using Leaf_Mobile.Model;
using Leaf_Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Leaf_Mobile.Services
{

	public class UsuarioServices
	{
		private readonly UsuarioRepository _usuarioRepository;

        public UsuarioServices(UsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}

		public Usuario ValidarUsuario(string login, string senha)
		{
			try
			{
				Usuario usuario = _usuarioRepository.ValidarUsuario(login, senha);

				//Somente usuario ativo e dos departamentos admin do sistema/logistica
				if (usuario != null && usuario.Status == 1)
				{
					if (usuario.Departamento?.Descricao == "ADMIN" || usuario.Departamento?.Descricao == "LOGÍSTICA")
					{
						return usuario;
					}
				}

				return new Usuario();

			}
			catch (Exception ex)
			{

				throw new Exception("Erro ao consultar usuário. " + ex.Message);
			}

		}
		
		public async Task<Usuario> GetUsuario(int idUsuario)
		{
			Usuario usuario = new Usuario();

			try
			{
				if (idUsuario != 0)
				{
					usuario = await _usuarioRepository.GetUsuarioById(idUsuario);
				}

				return usuario ?? new Usuario();

			}
			catch (Exception ex)
			{

				throw new Exception("Erro ao consultar usuário. " + ex.Message);
			}
			
		}

	}
}
