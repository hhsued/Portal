using System;
using System.Net.Http;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using MudBlazor.Services;
using AntDesign;
namespace Application
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

            appBuilder.Services
                .AddLogging();

            // register root component and selector
            appBuilder.RootComponents.Add<App>("app");
            appBuilder.Services.AddMudServices();
            appBuilder.Services.AddAntDesign();
						appBuilder.Services.AddSingleton<ParishLetter>();

            var app = appBuilder.Build();

            // customize window
            app.MainWindow
                .SetIconFile("favicon.ico")
                .SetTitle("Photino Blazor Sample");

            AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            {
                app.MainWindow.OpenAlertWindow("Fatal exception", error.ExceptionObject.ToString());
            };

            app.Run();

        }
    }
}
