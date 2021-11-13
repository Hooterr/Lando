using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Lando
{
	public static class MauiProgram
	{
		public static IServiceProvider ServiceProvider { get; private set; }

		public static MauiApp CreateMauiApp()
		{
			ServiceProvider = new ServiceCollection()
				.ConfigureServices()
				.BuildServiceProvider();

			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular")
						 .AddFont("Lato-Black.ttf", "Black")
						 .AddFont("Lato-BlackItalic.ttf", "BlackItalic")
						 .AddFont("Lato-Bold.ttf", "Bold")
						 .AddFont("LatoBoldItalic.ttf", "BoldItalic")
						 .AddFont("Lato-Italic.ttf", "Italic")
						 .AddFont("Lato-Light.ttf", "Light")
						 .AddFont("Lato-LightItalic.ttf", "LightItalic")
						 .AddFont("Lato-Regular.ttf", "Regular")
						 .AddFont("Lato-Thinen.ttf", "Thinen")
						 .AddFont("Lato-ThinItalic.ttf", "ThinItalic")
						 .AddFont("FontAwesomeFree-Solid-900.otf", "FA");
				});

			return builder.Build();
		}
	}
}