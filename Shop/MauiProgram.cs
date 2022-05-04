
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input; 
global using Shop.ViewModel;

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;

namespace Shop;

public static class MauiProgram
{
    public static TelemetryClient Telemetry { get; private set; }

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
		services.AddLogging(b =>
        {
			b.AddApplicationInsights("4e64ad7b-babd-497a-9e65-548e7359450b");
			b.SetMinimumLevel(LogLevel.Debug);
        });
		Telemetry = GetTelemetryClient();
		services.AddSingleton(Telemetry);
		services.AddSingleton<StateManager>();
		services.AddSingleton<NativeService>();
		services.AddSingleton<BoundServiceAbstraction>();


		AppDomain.CurrentDomain.UnhandledException += (s, e) =>
		{
			Task.Run(async () =>
			{
				System.Diagnostics.Debug.WriteLine("AppDomain.CurrentDomain.UnhandledException: {0}. IsTerminating: {1}", e.ExceptionObject, e.IsTerminating);
				await Task.Delay(1000).ConfigureAwait(false);
				Telemetry.TrackException(e.ExceptionObject as Exception);
				await Task.Delay(4000).ConfigureAwait(false);
			}).Wait();
		};
	}

	private static TelemetryClient GetTelemetryClient()
	{
		TelemetryConfiguration config = TelemetryConfiguration.CreateDefault();
		config.ConnectionString = "InstrumentationKey=4e64ad7b-babd-497a-9e65-548e7359450b;IngestionEndpoint=https://westus2-2.in.applicationinsights.azure.com/;LiveEndpoint=https://westus2.livediagnostics.monitor.azure.com/";
		QuickPulseTelemetryProcessor quickPulseProcessor = null;
		config.DefaultTelemetrySink.TelemetryProcessorChainBuilder
			.Use((next) =>
			{
				quickPulseProcessor = new QuickPulseTelemetryProcessor(next);
				return quickPulseProcessor;
			})
			.Build();

		var quickPulseModule = new QuickPulseTelemetryModule
		{
			AuthenticationApiKey = "62nqjo8mrn3b1tm8v6bpfzu1n7ib17st1oaaykwp",
		};
		quickPulseModule.Initialize(config);
		quickPulseModule.RegisterTelemetryProcessor(quickPulseProcessor);
		TelemetryClient client = new(config);
		return client;
	}

}
