using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using Leaf_Mobile.Model;
using Leaf_Mobile.Services.Facede;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Leaf_Mobile.Views;

namespace Leaf_Mobile.ViewModel
{
	public class PedidoViewModel : INotifyPropertyChanged
	{
		// Propriedades de manipulação de dados
		virtual public Pedido? Pedido { get; set; }
		virtual public List<PedidoItem?>? PedidoItem { get; set; }

		// Propriedade interna para manipulação com a interface
		private ObservableCollection<PedidoViewModel> _pedidos = new ObservableCollection<PedidoViewModel>();
		private bool _emUso;
		private bool _carregar;
		private bool _estaAtualizando;
		private bool _temPedido;
		private bool _notPedido;

		// Propriedade para controle de estado
		public bool EmUso
		{
			get => _emUso;
			set
			{
				_emUso = value;
				OnPropertyChanged();
			}
		}
		public bool Carregar
		{
			get => _carregar;
			set
			{
				_carregar = value;
				OnPropertyChanged();
			}
		}

		public bool TemPedidos
		{
			get => _temPedido;
			set
			{
				_temPedido = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(NaoTemPedidos));
			}
		}

		// NaoTemPedidos será o inverso de TemPedidos
		public bool NaoTemPedidos => !TemPedidos;


		// Propriedade de lista de pedidos
		public ObservableCollection<PedidoViewModel> Pedidos
		{
			get => _pedidos;
			set
			{
				_pedidos = value;
			}
		}

		// Serviços
		private readonly PedidoFacedeServices _pedidoFacedeServices;

		// Comando para manipular os métodos
		public ICommand AtualizarListaPedidosCommand { get; }

		// Contrutor
		public PedidoViewModel(PedidoFacedeServices pedidoFacedeServices)
		{
			_pedidoFacedeServices = pedidoFacedeServices;
			AtualizarListaPedidosCommand = new Command(async () => await AtualizarListaPedidos());
		}
		

		// Carregar Pedidos
		public async Task CarregarPedidos(int idUser)
		{
			if (_estaAtualizando) return;

			EmUso = true;
			try
			{
				var pedidosBase = await _pedidoFacedeServices.GetPedidos(idUser);
				Pedidos.Clear();

				foreach (var pedido in pedidosBase)
				{
					Pedidos.Add(pedido);
				}

				TemPedidos = Pedidos.LongCount() > 0;

			}
			finally
			{
				EmUso = false;
				var toast = Toast.Make("Pedidos Carregados", ToastDuration.Short, 14);
				await toast.Show();
			}
		}

		// Atualizar lista pedidos na view
		private async Task AtualizarListaPedidos()
		{
			if (_estaAtualizando) return; // Evita reentrância

			_estaAtualizando = true;
			Carregar = true;

			try
			{
				int idUser = Preferences.Get("IdUser", default(int));
				var pedidosCarregados = await _pedidoFacedeServices.GetPedidos(idUser);

				Pedidos.Clear();  // Limpa antes de adicionar

				foreach (var pedido in pedidosCarregados)
				{
					Pedidos.Add(pedido);
				}

				TemPedidos = Pedidos.LongCount() > 0;
			}
			finally
			{
				Carregar = false;
				_estaAtualizando = false;
				var toast = Toast.Make("Pedidos Atualizados", ToastDuration.Short, 14);
				await toast.Show();
			}
		}

		public async Task<ErrorViewModel> BaixarPedido(int idEntregador, int idPedido)
		{
			if (idEntregador <= 0 && idPedido <= 0)
			{
				return new ErrorViewModel(false, "Pedido ou Usuário inválido.");
			}
			try
			{
				ErrorViewModel resultado = await _pedidoFacedeServices.AtulizarPedido(idEntregador, idPedido);

				if (resultado.Sucesso)
				{
					return resultado;
				}

				return resultado;
			}
			catch (Exception ex)
			{
				return new ErrorViewModel(false, "Erro ao atualizar status", ex.Message);
			}

		}

		

		// Metodo para registrar mudanças em minhas propriedades
		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
