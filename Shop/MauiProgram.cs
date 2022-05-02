
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input; 
global using Shop.ViewModel;

namespace Shop;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("junegull.ttf", "JuneGull");
			});

		builder.Services.AddSingleton<HomeViewModel>();
		builder.Services.AddSingleton<HomePage>();
		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));

		builder.Services.AddSingleton<DetailViewModel>();
		builder.Services.AddSingleton<DetailPage>();
		Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));

		builder.Services.AddSingleton<DeepViewModel>();
		builder.Services.AddSingleton<DeepPage>();
		Routing.RegisterRoute(nameof(DeepPage), typeof(DeepPage));

		builder.Services.AddSingleton<MVUViewModel>();
		builder.Services.AddSingleton<MVUPage>();
		Routing.RegisterRoute(nameof(MVUPage), typeof(MVUPage));

		return builder.Build();
	}
}
