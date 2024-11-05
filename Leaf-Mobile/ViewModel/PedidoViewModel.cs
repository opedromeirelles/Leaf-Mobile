using Leaf_Mobile.Model;
using Leaf_Mobile.Services.Facede;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Leaf_Mobile.ViewModel
{
	public class PedidoViewModel : INotifyPropertyChanged
	{
		// Propriedades de manipulação de dados
		virtual public Pedido? Pedido { get; set; }
		virtual public List<PedidoItem?>? PedidoItem { get; set; }

		// Propriedade interna para manipulação com a interface
		private ObservableCollection<PedidoViewModel>? _pedidos;
		private bool _emUso;

		//Propriedade para controle de estado
        public bool EmUso 
		{ 
			get => _emUso; 
			set
			{
				_emUso = value;
				OnPropertyChanged();
			} 
		}

		//Propriedade de lista de pedidos
        public ObservableCollection<PedidoViewModel> Pedidos
		{
			get => _pedidos ?? new ObservableCollection<PedidoViewModel>();
			set
			{
				_pedidos = value;
				OnPropertyChanged();
			}
		}

		// Serviços
		private readonly PedidoFacedeServices _pedidoFacedeServices;


		//-----------------------------//


		//Contrutor
        public PedidoViewModel(PedidoFacedeServices pedidoFacedeServices)
        {
            _pedidoFacedeServices = pedidoFacedeServices;
			Pedidos = new ObservableCollection<PedidoViewModel>();
        }


		//Carregar Pedidos
		public async Task CarregarPedidos(int idUser)
		{
			EmUso = true;
			try
			{
				var pedidosBase = await _pedidoFacedeServices.GetPedidos(idUser);
				Pedidos.Clear();

				foreach (var pedido in pedidosBase)
				{
					Pedidos.Add(pedido);
				}

			}
			catch (Exception ex)
			{
				throw new Exception("Não foi possivel consultar a lista de pedidos. " + ex.Message);
			}
			finally
			{
				EmUso = false;
			}
		}

		//Atualizar Pedido
		public async Task<ErrorViewModel> BaixarPedido(int idEntregador, int idPedido)
		{
			EmUso = true;
			try
			{
				ErrorViewModel resultado = await _pedidoFacedeServices.AtulizarPedido(idEntregador, idPedido);
				if (resultado.Sucesso)
				{
					return new ErrorViewModel(true, resultado.Mensagem!);
				}
				else
				{
					return new ErrorViewModel(false, resultado.Mensagem!);
				}
			}
			catch (Exception ex)
			{
				ErrorViewModel error = new ErrorViewModel(false, "Erro Atualizar Pedido", ex.Message);
				return error;

			}
			finally
			{
				EmUso = false;
			}
		}






		//-----------------------------//


		// Implementação do INotifyPropertyChanged para notificação de mudanças em meus objetos
		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


	}
}
