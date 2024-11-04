namespace Leaf_Mobile
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			// Define a NavigationPage como a página principal com estilo de barra de navegação
			MainPage = new NavigationPage(new MainPage())
			{
				BarBackgroundColor = Color.FromArgb("#589b3c"),      // Cor de fundo da barra de navegação
				BarTextColor = Colors.White,                         // Cor do texto na barra de navegação
				BarBackground = new LinearGradientBrush(             // Gradiente como fundo
				new GradientStopCollection
				{
					new GradientStop(Color.FromArgb("#589b3c"), 0.0f),
					new GradientStop(Color.FromArgb("#8fd457"), 1.0f)
				},
				new Point(0, 0), new Point(1, 0))
			};
		}
	}
}
