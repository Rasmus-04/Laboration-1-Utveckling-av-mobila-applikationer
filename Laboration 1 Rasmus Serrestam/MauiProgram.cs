using Microsoft.Extensions.Logging;
using Laboration_1_Rasmus_Serrestam.Data;
using Microsoft.EntityFrameworkCore;

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



            return builder.Build();
        }
    }
}
