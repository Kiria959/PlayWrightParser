using Microsoft.Playwright;
using System;
using Serilog;


namespace ParserDopolneniy.Core
{
    using ParserDopolneniy.Core.ParcimSaiti;
    using System.Net;

    namespace Parser.Core
    {
        class HtmlLoader
        {
            private readonly IParserSettings settings;
            private bool IsInitialized = false;
            private IBrowserContext context;
            private IBrowser browser;
            IPlaywright playwright;
            readonly string url;

            public HtmlLoader(IParserSettings settings)
            {
               this.settings = settings;
                url = $"{settings.BaseUrl}/{settings.Prefix}/";
            }
            public async Task InitializeAsync()
            { 
                if(IsInitialized) { return; }

                try
                {
                 
                    playwright = await Playwright.CreateAsync();
                    browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = settings.Headless, SlowMo = 300 }); 

                    context = await browser.NewContextAsync(new BrowserNewContextOptions {UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36",
                        ViewportSize = new ViewportSize {Width = 1920, Height = 1080 }, Locale = "ru-RU", TimezoneId = "Europe/Moscow" });
                    IsInitialized = true;
                    Log.Information("Playwright is running");
                }
                catch (Exception ex)
                {
                    Log.Fatal("Браузер пал, милорд, проверьте их наличие на playwright install");
                    throw;
                }
            }

            public async Task<string> GetSourseByPageId(int id)
            {
                if (!IsInitialized) { await InitializeAsync(); }
                var currentUrl = settings.GetUrlForPage(id);
                string sourse = null;
                var page = await context.NewPageAsync();
                page.SetDefaultNavigationTimeout(60000);

                try
                {
                    Log.Debug($"Переход на {currentUrl} {id}");
                    await Task.Delay(new Random().Next(1000, 3000));
                    var response = await page.GotoAsync(currentUrl);
                    
                    if (response == null) { Log.Warning("Запрос без ответа"); }
                    if (response.Status == 200 && response != null)
                    {
                        try
                        {
                            await page.WaitForSelectorAsync("a[data-marker='item-title']", new() { Timeout = 5000 });
                        }
                        catch { }
                        sourse = await page.ContentAsync();
                    }
                    if (response.Status == 404 || response.Status == 403) { Log.Warning("Запрос отклонён, милорд, послу рубанули голову"); }
                    else { Log.Warning("Посол пропал без вести на проклятой земле"); }
                }
                catch (Exception)
                {
                    Log.Error($"Error, {id}");
                    
                }
                finally
                {
                    await page.CloseAsync();
                }
                return sourse;

            }

            public async Task DisposeAsync()
            {
                if (context != null) { await context.CloseAsync(); }
                if (browser != null) { await browser.CloseAsync(); }
                playwright?.Dispose();
                Log.Information("Работа завершена");
            }

        }
    }
}
