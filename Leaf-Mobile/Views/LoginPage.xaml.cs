using Leaf_Mobile.ViewModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Leaf_Mobile.Views;

public partial class LoginPage : ContentPage
{
	private readonly UsuarioViewModel _usuarioViewModel;
	private readonly IServiceProvider _serviceProvider;

	//Construtor
	public LoginPage(UsuarioViewModel usuarioViewModel, IServiceProvider serviceProvider)
	{
		_usuarioViewModel = usuarioViewModel;
		_serviceProvider = serviceProvider;
		InitializeComponent();
	}

	//Botao de entrar
	private async void btnLogin_Clicked(object sender, EventArgs e)
	{
		string login = entryUsername.Text;
		string senha = entrySenha.Text;

		// Validação de entrada
		if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
		{
			await DisplayAlert("Erro", "Por favor, insira o login de usuário e senha.", "OK");
			return;
		}

		// Mensagem de autenticação
		var toast = Toast.Make("Autenticando...", ToastDuration.Short, 14);
		await toast.Show();

		// Lógica de autenticação
		ErrorViewModel error = _usuarioViewModel.Validarlogin(login, senha);

		if (error.Sucesso)
		{
			// Usando o serviceProvider para obter uma instância da MainPage com as dependências configuradas
			var mainPage = _serviceProvider.GetRequiredService<MainPage>();

			// Define a MainPage dentro de uma NavigationPage
			Application.Current!.MainPage = new NavigationPage(mainPage)
			{
				BarBackgroundColor = Color.FromArgb("#589b3c"),
				BarTextColor = Colors.White,
				BarBackground = new LinearGradientBrush(
					new GradientStopCollection
					{
						new GradientStop(Color.FromArgb("#589b3c"), 0.0f),
						new GradientStop(Color.FromArgb("#8fd457"), 1.0f)
					},
					new Point(0, 0), new Point(1, 0)
				)
			};
		}
		else
		{
			string erroFormatado = error.ErroFormatado(error);
			await DisplayAlert("Validação", erroFormatado, "OK");
		}
	}

	//Botao de desligar
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
			// Fecha a aplicação
			System.Environment.Exit(0);
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


}