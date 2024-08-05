using Microsoft.Extensions.Logging;
using Twilio;
namespace BloodConnect
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            TwilioClient.Init("AC29bc8545692d6d112f1b0de0ef097d63", "55c1ec736c6e967117b0c67d36056905");
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialFonts.ttf", "mf");
                    fonts.AddFont("FontAwesomeRegular.otf", "far");
                    fonts.AddFont("FontAwesomeSolid.otf", "fas");

                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
