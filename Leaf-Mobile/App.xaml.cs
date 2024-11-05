using Leaf_Mobile.ViewModel;
using Leaf_Mobile.Views;
using CommunityToolkit.Maui;
using Xamarin.Google.Crypto.Tink.Subtle;

namespace Leaf_Mobile
{
	public partial class App : Application
	{

		private readonly UsuarioViewModel _usuarioViewModel;

		public App(UsuarioViewModel usuarioViewModel)
		{
			_usuarioViewModel = usuarioViewModel;

			bool isLoggedIn = Preferences.Get("UserLoggedIn", false);

			InitializeComponent();

			if (isLoggedIn)
			{
				MainPage = new NavigationPage(new MainPage(_usuarioViewModel))
				{
					BarBackgroundColor = Color.FromArgb("#589b3c"), // Cor de fundo da barra de navegação
					BarTextColor = Colors.White,                    // Cor do texto na barra de navegação
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
				MainPage = new LoginPage(_usuarioViewModel);
			}
		}
	}
}
