using Leaf_Mobile.ViewModel;
using Leaf_Mobile.Views;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace Leaf_Mobile
{
	public partial class App : Application
	{
		private readonly UsuarioViewModel _usuarioViewModel;
		private readonly IServiceProvider _serviceProvider;

		//Inicialização do sistema
		public App(UsuarioViewModel usuarioViewModel, IServiceProvider serviceProvider)
		{
			_usuarioViewModel = usuarioViewModel;
			_serviceProvider = serviceProvider;

			bool isLoggedIn = Preferences.Get("UserLoggedIn", false);

			InitializeComponent();


			//Vejo se há preferences
			if (isLoggedIn)
			{
				// Resolve a MainPage e configura a navegação
				var mainPage = _serviceProvider.GetRequiredService<MainPage>();

				MainPage = new NavigationPage(mainPage)
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
				// Resolve a LoginPage com os serviços injetados
				var mainPage = _serviceProvider.GetRequiredService<LoginPage>();
				MainPage = new NavigationPage(mainPage)
				{
					BarBackgroundColor = Color.FromArgb("#589b3c"), // Cor de fundo da barra de navegação
					BarTextColor = Colors.White                    // Cor do texto na barra de navegação

				};
			}
		}
	}
}
