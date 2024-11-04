using Leaf_Mobile.Views;

namespace Leaf_Mobile
{
	public partial class MainPage : ContentPage
	{
		// private readonly DbConnectionManager _dbConnectionManager;
		

		public MainPage()
		{
			// _dbConnectionManager = dbConnectionManager;
			InitializeComponent();
		}
		
		// Método para aplicar o efeito de clique na imagem
		private async Task ApplyClickAnimation(VisualElement element)
		{
			// Animação de clique (reduz opacidade e escala)
			await Task.WhenAll(
				element.FadeTo(0.6, 30),    // Diminui a opacidade para 60% em 50 ms
				element.ScaleTo(0.9, 30)    // Diminui a escala para 90% em 50 ms
			);

			// Restaura a opacidade e a escala ao normal
			await Task.WhenAll(
				element.FadeTo(1, 40),
				element.ScaleTo(1, 40)	
			);
		}

		private async void ImgDetalhes_click(object sender, TappedEventArgs e)
		{
			var image = (Image)sender;
			await ApplyClickAnimation(image);

			await Navigation.PushAsync(new PedidoPage());
		}

		private async void ImgLogOff_click(object sender, TappedEventArgs e)
		{
			var image = (Image)sender;
			await ApplyClickAnimation(image);

			await DisplayAlert("Sair de Leaf", "Deseja sair do aplicativo ?", "Sim", "Não");
		}
	}

}
