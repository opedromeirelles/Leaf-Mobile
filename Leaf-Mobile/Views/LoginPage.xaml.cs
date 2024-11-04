namespace Leaf_Mobile.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void btnLogin_Clicked(object sender, EventArgs e)
	{
		string username = entryUsername.Text;
		string password = entrySenha.Text;

		// Valida��o de entrada
		if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
		{
			await DisplayAlert("Erro", "Por favor, insira nome de usu�rio e senha.", "OK");
			return;
		}

		// L�gica de autentica��o (exemplo)
		if (username == "admin" && password == "123") // Substitua pela l�gica real de autentica��o
		{
			// Redefine a MainPage como uma nova NavigationPage com estilo de barra de navega��o
			Application.Current!.MainPage = new NavigationPage(new MainPage())
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
			await DisplayAlert("Erro", "Nome de usu�rio ou senha incorretos.", "OK");
		}

	}
}