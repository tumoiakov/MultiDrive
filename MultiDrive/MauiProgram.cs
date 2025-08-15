using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MultiDrive.Shared.Database;
using System;

namespace MultiDrive
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

            string DBFilename = "MultidriveDB.db3";
            string DBPath = Path.Combine(FileSystem.AppDataDirectory, DBFilename);

            builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlite($"Data Source={DBPath}"));
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
