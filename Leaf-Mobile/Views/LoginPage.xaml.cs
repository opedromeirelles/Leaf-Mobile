using Leaf_Mobile.ViewModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Android.Preferences;

namespace Leaf_Mobile.Views;


public partial class LoginPage : ContentPage
{
	private ErrorViewModel? _errorViewModel;
	private readonly UsuarioViewModel _usuarioViewModel;


	public LoginPage(UsuarioViewModel usuarioViewModel)
	{
		_usuarioViewModel = usuarioViewModel;
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

		var toast = Toast.Make("Autenticando..", ToastDuration.Short, 14);
		await toast.Show();


		try
		{
			// L�gica de autentica��o 
			_errorViewModel = _usuarioViewModel.Validarlogin(login, senha);

			if (_errorViewModel.Sucesso)
			{
				// Redefine a MainPage como uma nova NavigationPage com estilo de barra de navega��o
				Application.Current!.MainPage = new NavigationPage(new MainPage(_usuarioViewModel))
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
		finally
		{
			toast = Toast.Make("Usu�rio Autenticado!", ToastDuration.Short, 14);
			await toast.Show();
		}
	}

}