using CommunityToolkit.Maui;
using LoL_Champions.ViewModels;
using Microsoft.Extensions.Logging;
using Model;
using StubLib;
using VM;

namespace LoL_Champions
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                   .UseMauiCommunityToolkit()
                   .ConfigureFonts(fonts =>
                   {
                       fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                       fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                   });

            builder.Services.AddSingleton<IDataManager, StubData>()
                            .AddSingleton<ChampionManagerVM>()
                            .AddSingleton<AddOrEditChampionVM>()
                            .AddSingleton<AddOrEditSkinVM>()
                            .AddSingleton<AppVM>()
                            .AddSingleton<App>();
            
        #if DEBUG
		    builder.Logging.AddDebug();
        #endif

            return builder.Build();
        }
    }
}