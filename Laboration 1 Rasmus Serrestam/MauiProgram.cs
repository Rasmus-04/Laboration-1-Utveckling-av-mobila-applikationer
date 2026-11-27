using Laboration_1_Rasmus_Serrestam.Data;
using Laboration_1_Rasmus_Serrestam.Services;
using Laboration_1_Rasmus_Serrestam.ViewModels;
using Laboration_1_Rasmus_Serrestam.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Laboration_1_Rasmus_Serrestam
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            // Defualt template code
            var builder = MauiApp.CreateBuilder();
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


            // FileSystem.AppDataDirectory är en katalog som är avsedd för applikationens egna data på enheten alltså lokalt på telefånen eller emulatorn
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Marketplace.db3");
            builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite($"Data Source={databasePath}"));

            builder.Services.AddSingleton<DatabaseInitializer>();
            builder.Services.AddTransient<ItemService>();

            builder.Services.AddTransient<AppShell>();

            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<ItemDetailsViewModel>();
            builder.Services.AddTransient<ItemDetailsPage>();


            return builder.Build();
        }
    }
}
