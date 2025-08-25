using Microsoft.Extensions.Logging;

namespace WebviewFileSelect
{
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
				});

			//ConfigureHandlers(builder);

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}

		static MauiAppBuilder ConfigureHandlers(MauiAppBuilder builder)
		{
#if __ANDROID__
            builder.ConfigureMauiHandlers(handlers =>
				{
					Microsoft.Maui.Handlers.WebViewHandler.Mapper.ReplaceMapping<WebView, Microsoft.Maui.Handlers.WebViewHandler>("WebChromeClient", (handler, virtualView) =>
					{
						if (handler is Microsoft.Maui.Handlers.WebViewHandler platformHandler)
							handler.PlatformView.SetWebChromeClient(new Platforms.Android.MultiFileWebChromeClient(platformHandler));
					});
				});
#endif

			return builder;
		}
	}
}
