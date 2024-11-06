using Leaf_Mobile.Model;
using Leaf_Mobile.ViewModel;

namespace Leaf_Mobile.Services.Facede
{
	public class PedidoFacedeServices
	{
		//Serviços
		private readonly PessoaServices _pessoaServices;
		private readonly ProdutoServices _produtoServices;
		private readonly PedidoServices _pedidoServices;
		private readonly PedidoItemServices _pedidoItemServices;
		private readonly UsuarioServices _usuarioServices;

		//instanciando injeção direta dos serviços
		public PedidoFacedeServices(UsuarioServices usuarioServices, PessoaServices pessoaServices, ProdutoServices produtoServices, PedidoServices pedidoServices, PedidoItemServices pedidoItemServices)
		{
			_usuarioServices = usuarioServices;
			_pessoaServices = pessoaServices;
			_produtoServices = produtoServices;
			_pedidoItemServices = pedidoItemServices;
			_pedidoServices = pedidoServices;
		}

		//Mapear Pedido
		private async Task<PedidoViewModel> MapeaPedido(int idPedido)
		{
			//Valido o id do pedido
			if (idPedido <= 0)
			{
				return new PedidoViewModel(this);
			}

			try
			{
				
				PedidoViewModel pedidoViewModel = new PedidoViewModel(this);

				pedidoViewModel.Pedido = await _pedidoServices.GetPedido(idPedido);
				pedidoViewModel.PedidoItem = await _pedidoItemServices.GetPedidoItems(idPedido);
				pedidoViewModel.Pedido.Entregador = await _usuarioServices.GetUsuario(pedidoViewModel.Pedido.IdEntregador);
				pedidoViewModel.Pedido.Vendedor = await _usuarioServices.GetUsuario(pedidoViewModel.Pedido.IdVendedor);
				pedidoViewModel.Pedido.Pessoa = await _pessoaServices.GetPessoa(pedidoViewModel.Pedido.IdPessoa);


				foreach (var item in pedidoViewModel.PedidoItem)
				{
					if (item != null)
					{
						item.Produto = await _produtoServices.GetProduto(item.IdProduto);
						item.Produtos?.Add(item.Produto);
					}
				}

				//Verifico se esta vazio, retorno ele
				return pedidoViewModel ?? new PedidoViewModel(this);

			}
			catch (Exception ex)
			{

				throw new Exception("Erro ao mapear pedido. " + ex.Message);
			}


		}

		//Get Pedido especifico (Mapeado)
		public async Task<PedidoViewModel> GetPedido(int idPedido)
		{
			PedidoViewModel pedidoViewModel = new PedidoViewModel(this);
			if (idPedido > 0)
			{
				pedidoViewModel = await MapeaPedido(idPedido);
			}
			return pedidoViewModel;
		}

		//Get lista de pedidos (Mapeado)
		public async Task<List<PedidoViewModel>> GetPedidos(int idUser)
		{
			List<Pedido> pedidos = new List<Pedido>();
			List<PedidoViewModel> pedidoViews = new List<PedidoViewModel>();

			try
			{
				pedidos = await _pedidoServices.GetPedidos();
				pedidos = await PedidosPorResponsavel(pedidos, idUser);

                foreach (var pedido in pedidos)
                {
					PedidoViewModel pedidoView = await MapeaPedido(pedido.IdPedido);
					pedidoViews.Add(pedidoView);
                }

				return pedidoViews.Any() ? pedidoViews : new List<PedidoViewModel>();
            }
			catch (Exception ex)
			{

				throw new Exception("Erro ao mapear pedidos. " + ex.Message);
			}
		}

		//Filtrar pedido por entregador
		public async Task<List<Pedido>> PedidosPorResponsavel(List<Pedido> pedidos, int idUser)
		{
			// Objetos vazios
			List<Pedido> pediosEntregador = new List<Pedido>();
			Usuario usuario = new Usuario();

			//Conultar se o id é referente a um entregador mesmo, ou se é de um admin do sistema
			usuario = await _usuarioServices.GetUsuario(idUser);

			if (usuario.Departamento?.Descricao == "ADMIN")
			{
				return pedidos;
			}
			else if (usuario.Departamento?.Descricao == "LOGÍSTICA")
			{

				pediosEntregador = pedidos.Where(p => p.IdEntregador == idUser).ToList();

				return pediosEntregador;
			}

			return new List<Pedido>();
		}

		//Atualizar pedido
		public async Task<ErrorViewModel> AtulizarPedido(int idEntregador, int idPedido)
		{
			Pedido pedido = new Pedido();

			if (idEntregador <= 0 || idPedido <= 0)
			{
				return new ErrorViewModel(false, "Entregador ou Pedido inválido, tente novamente");
			}

			try
			{
				pedido = await _pedidoServices.GetPedido(idPedido);

				if (pedido != null && pedido.Status == "RT")
				{
					if (_pedidoServices.AtulizarStatusPedido(idEntregador, idPedido))
					{
						return new ErrorViewModel(true, "Pedido baixado com sucesso.");
					}

					return new ErrorViewModel(false, "Erro ao baixar pedido, tente novamente");

				}
				else
				{
					return new ErrorViewModel(false, "Esse pedido não está disponivel para entrega, informe seu administrativo");
				}
			}
			catch (Exception ex)
			{

				ErrorViewModel error = new ErrorViewModel(false, "Erro ao validar pedido", ex.Message);
				error.Mensagem = error.ErroFormatado(error);

				return new ErrorViewModel(false, error.Mensagem);
			}
		}

	}
}
