﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Storage;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Leaf_Mobile.Data;
using Leaf.Repository.Agentes;
using Leaf_Mobile.Services;
using Leaf_Mobile.Views;
using Leaf_Mobile.ViewModel;
using CommunityToolkit.Maui;
using Leaf_Mobile.Services.Facede;
using Leaf.Repository.Pedidos;
using Leaf.Repository.Materiais;
using Leaf.Repository.Departamentos;

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

			// Registrar o DbConnectionManager para injeção de dependência
			builder.Services.AddSingleton<DbConnectionManager>(); 

			// Registrar Serviços
			builder.Services.AddTransient<UsuarioServices>();
			builder.Services.AddTransient<PedidoFacedeServices>();
			builder.Services.AddTransient<PedidoItemServices>();
			builder.Services.AddTransient<PedidoServices>();
			builder.Services.AddTransient<PessoaServices>();
			builder.Services.AddTransient<ProdutoServices>();



			// Reistrar Repositórios
			builder.Services.AddTransient<UsuarioRepository>();
			builder.Services.AddTransient<PedidoItemRepository>();
			builder.Services.AddTransient<PedidoRepository>();
			builder.Services.AddTransient<PessoaRepository>();
			builder.Services.AddTransient<ProdutoRepository>();
			builder.Services.AddTransient<DepartamentoRepository>();


			// Registrar chamadas ModelView
			builder.Services.AddTransient<UsuarioViewModel>();
			builder.Services.AddTransient<PedidoViewModel>();



			// Registrar chamadas Views
			builder.Services.AddTransient<LoginPage>();
			builder.Services.AddTransient<MainPage>();
			builder.Services.AddTransient<PedidoPage>();




			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
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
