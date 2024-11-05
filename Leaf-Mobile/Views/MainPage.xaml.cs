using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using Leaf_Mobile.ViewModel;
using Leaf_Mobile.Views;
using Leaf_Mobile.Services.Facede;
using Microsoft.Maui.Controls;

namespace Leaf_Mobile
{
	public partial class MainPage : ContentPage
	{
		// Serviços
		private readonly UsuarioViewModel _usuarioViewModel;
		private readonly PedidoFacedeServices _pedidoFacedeServices;
		private readonly PedidoViewModel _pedidoViewModel;
		private readonly IServiceProvider _serviceProvider;

		// Variáveis de controle
		private bool _paginaCarreagada = false;

		public MainPage(UsuarioViewModel usuarioViewModel, PedidoFacedeServices pedidoFacedeServices, IServiceProvider serviceProvider)
		{
			_usuarioViewModel = usuarioViewModel;
			_pedidoFacedeServices = pedidoFacedeServices;
			_pedidoViewModel = new PedidoViewModel(pedidoFacedeServices);
			_serviceProvider = serviceProvider;

			BindingContext = _pedidoViewModel;
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			if (!_paginaCarreagada)
			{
				var toast = Toast.Make("Usuário Autenticado!", ToastDuration.Short, 14);
				await toast.Show();
				_paginaCarreagada = true;
			}

			await _pedidoViewModel.CarregarPedidos(_usuarioViewModel.Id);
			base.OnAppearing();
		}

		// Método para fazer logoff e redirecionar para a LoginPage
		private async void ImgLogOff_click(object sender, TappedEventArgs e)
		{
			var image = (Image)sender;
			await ApplyClickAnimation(image);

			bool resposta = await DisplayAlert("Sair do sistema",
												"Tem certeza que deseja sair?",
												"Sim",
												"Não");
			if (resposta)
			{
				// Remove as preferências de login
				Preferences.Clear();

				// Obtém uma nova instância da LoginPage a partir do serviceProvider
				var loginPage = _serviceProvider.GetRequiredService<LoginPage>();

				// Redefine a MainPage para a tela de login
				Application.Current!.MainPage = new NavigationPage(loginPage);
			}
		}

		// Método para aplicar o efeito de clique na imagem
		private async Task ApplyClickAnimation(VisualElement element)
		{
			await Task.WhenAll(
				element.FadeTo(0.6, 30),
				element.ScaleTo(0.9, 30)
			);

			await Task.WhenAll(
				element.FadeTo(1, 40),
				element.ScaleTo(1, 40)
			);
		}

		private async void ImgDetalhes_click(object sender, TappedEventArgs e)
		{
			var image = (Image)sender;
			await ApplyClickAnimation(image);

			await DisplayAlert("Detalhes", "Aqui sera os detalhes do pedido", "OK");

		}
	}
}
