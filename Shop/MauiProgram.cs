
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

		RegisterDependencies(builder.Services);

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

		builder.Services.AddSingleton<BoundServiceViewModel>();
		builder.Services.AddSingleton<BoundServicePage>();
		Routing.RegisterRoute(nameof(BoundServicePage), typeof(BoundServicePage));

		builder.Services.AddSingleton<NativeViewModel>();
		builder.Services.AddSingleton<NativePage>();
		Routing.RegisterRoute(nameof(NativePage), typeof(NativePage));

		builder.Services.AddSingleton<DynamicFruitViewModel>();
		builder.Services.AddSingleton<DynamicFruitPage>();
		Routing.RegisterRoute(nameof(DynamicFruitPage), typeof(DynamicFruitPage));
		
		builder.Services.AddSingleton<FormViewModel>();
		builder.Services.AddSingleton<FormPage>();
		Routing.RegisterRoute(nameof(FormPage), typeof(FormPage));

		return builder.Build();
	}

    private static void RegisterDependencies(IServiceCollection services)
    {
		services.AddSingleton<StateManager>();
		services.AddSingleton<NativeService>();
		services.AddSingleton<BoundServiceAbstraction>();
    }
}
