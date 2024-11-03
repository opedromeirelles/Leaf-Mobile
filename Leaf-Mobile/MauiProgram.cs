using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Leaf_Mobile.Data;

namespace Leaf_Mobile
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();

			// Configurar a leitura do arquivo appsettings.json
			var assembly = Assembly.GetExecutingAssembly();
			using var stream = assembly.GetManifestResourceStream("Leaf_Mobile.appsettings.json");

			if (stream == null)
			{
				throw new FileNotFoundException("O arquivo appsettings.json não foi encontrado como um recurso incorporado.");
			}

			var configuration = new ConfigurationBuilder()
				.AddJsonStream(stream)
				.Build();

			// Adicionar a configuração ao builder
			builder.Configuration.AddConfiguration(configuration);

			// Registrar serviços
			builder.Services.AddSingleton<DbConnectionManager>(); // Registrar o DbConnectionManager para injeção de dependência

			builder.Services.AddSingleton<MainPage>(); //Pagina

			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
