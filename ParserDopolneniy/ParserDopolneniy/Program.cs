using Serilog;
using Serilog.Core;
using System;

namespace ParserDopolneniy
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/parserAvito_log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Парсер успешно запущен!");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            Log.CloseAndFlush();
        }
    }
}