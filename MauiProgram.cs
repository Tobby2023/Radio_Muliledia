using Microsoft.Extensions.Logging;
using Radio.FM.Data;

namespace Radio.FM
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();
            
            builder.Services.AddScoped<HttpClient>(s =>
            {
                return new HttpClient { BaseAddress = new Uri(@"https://radios.vpn.sapo.pt/") };
            });

            return builder.Build();
        }
    }
}