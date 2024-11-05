using Leaf_Mobile.ViewModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Leaf_Mobile.Views;

public partial class LoginPage : ContentPage
{
	private ErrorViewModel? _errorViewModel;
	private readonly UsuarioViewModel _usuarioViewModel;
	private readonly IServiceProvider _serviceProvider;

	public LoginPage(UsuarioViewModel usuarioViewModel, IServiceProvider serviceProvider)
	{
		_usuarioViewModel = usuarioViewModel;
		_serviceProvider = serviceProvider;
		InitializeComponent();
	}

	private async void btnLogin_Clicked(object sender, EventArgs e)
	{
		string login = entryUsername.Text;
		string senha = entrySenha.Text;

		// Valida��o de entrada
		if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
		{
			await DisplayAlert("Erro", "Por favor, insira o login de usu�rio e senha.", "OK");
			return;
		}

		// Mensagem de autentica��o
		var toast = Toast.Make("Autenticando...", ToastDuration.Short, 14);
		await toast.Show();

		// L�gica de autentica��o
		_errorViewModel = _usuarioViewModel.Validarlogin(login, senha);

		if (_errorViewModel.Sucesso)
		{
			// Usando o serviceProvider para obter uma inst�ncia da MainPage com as depend�ncias configuradas
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
			string erroFormatado = _errorViewModel.ErroFormatado(_errorViewModel);
			await DisplayAlert("Valida��o", erroFormatado, "OK");
		}
	}
}
