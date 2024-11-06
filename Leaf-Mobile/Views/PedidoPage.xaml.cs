using Leaf_Mobile.ViewModel;

namespace Leaf_Mobile.Views;

public partial class PedidoPage : ContentPage
{
	public PedidoViewModel Pedido { get; set; }

	private readonly IServiceProvider _serviceProvider;

	public PedidoPage(PedidoViewModel pedidoSelecionado, IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
		Pedido = pedidoSelecionado;
		BindingContext = Pedido;
		InitializeComponent();
	}

	private async void btnBaixarPedido_Clicked(object sender, EventArgs e)
	{
		// Obt�m o bot�o que foi clicado
		var button = sender as Button;

		// Obt�m o par�metro de comando, que ser� o Pedido associado
		var pedido = button?.CommandParameter as PedidoViewModel;

		if (pedido != null)
		{
			await BaixarPedido(pedido);
		}
	}

	// M�todo exemplo para baixar o pedido
	private async Task BaixarPedido(PedidoViewModel pedido)
	{
		// L�gica para baixar o pedido
		int idEntregador = Preferences.Get("IdUser", default(int));

		bool opcao = await DisplayAlert("Confirmar Entrega",
											 "Deseja confirmar a entrega ? essa a��o n�o podera ser desfeita.",
											  "Confirmar",
											   "Revisar");
		if (opcao)
		{
			var resultado = await pedido.BaixarPedido(idEntregador, pedido!.Pedido!.IdPedido);

			if (resultado.Sucesso)
			{
				await DisplayAlert("Pedido Atualizado", resultado.Mensagem, "OK");

				// Resolve a MainPage e configura a navega��o
				var mainPage = _serviceProvider.GetRequiredService<MainPage>();

				Application.Current!.MainPage = new NavigationPage(mainPage)
				{
					BarBackgroundColor = Color.FromArgb("#589b3c"), // Cor de fundo da barra de navega��o
					BarTextColor = Colors.White,                    // Cor do texto na barra de navega��o
					BarBackground = new LinearGradientBrush(        // Gradiente como fundo
						new GradientStopCollection
						{
							new GradientStop(Color.FromArgb("#589b3c"), 0.0f),
							new GradientStop(Color.FromArgb("#8fd457"), 1.0f)
						},
						new Point(0, 0), new Point(1, 0) // Gradiente de esquerda para direita
					)
				};
			}
			else
			{
				await DisplayAlert("Erro ao atualizar pedido", resultado.Mensagem, "OK");
			}

		}

	}
}