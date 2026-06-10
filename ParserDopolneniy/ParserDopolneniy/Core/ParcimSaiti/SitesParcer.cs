using AngleSharp.Html.Dom;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserDopolneniy.Core.ParcimSaiti
{
    internal class SitesParcer : IParser<string[]>
    {
            public string[] Parse(IHtmlDocument document)
                {
                    if (document == null) return Array.Empty<string>();

                    var list = new List<string>();
                    // Ищем ВСЕ ссылки на сайте, у которых в адресе (href) есть "/kvartiry/"
                    // и которые содержат хоть какой-то текст внутри.
                    var items = document.QuerySelectorAll("a")
                        .Where(link => link.GetAttribute("href") != null &&
                                       link.GetAttribute("href").Contains("/kvartiry/") &&
                                       !string.IsNullOrEmpty(link.TextContent?.Trim()))
                        .ToList();
                    //log кста хранятся в папке bin/Debug/9.0net/Logs
                    Log.Information("AngleSharp нашел {Count} потенциальных ссылок на квартиры.", items.Count);

                    foreach (var item in items)
                    {
                        string title = item.TextContent?.Trim();

                        // Исключаем дубликаты (Авито может дублировать текст в картинке и заголовке)
                        // и убираем системные строки вроде "Купить квартиру"
                        if (!string.IsNullOrEmpty(title) && !list.Contains(title) && title.Length > 10)
                        {
                            list.Add(title);
                        }
                    }

                    if (list.Count == 0)
                    {
                        Log.Warning("Первый способ не сработал. Попробуем вывести структуру первого тега <a> для диагностики.");
                        var sample = document.QuerySelector("a[href*='/kvartiry/']");
                        if (sample != null)
                        {
                            Log.Debug($"Пример найденной ссылки: OuterHTML = { sample.OuterHtml}");
                        }
                    }
                    else
                    {
                        Log.Information($"Отобрано {list.Count} уникальных заголовков квартир.");
                    }

                    return list.ToArray();
                }
           //Эт первые наработки кода можете удалить, я хотел их пытаться чинить поэтому себе оставлю. Поиск тут сломан и в выводе всегда пусто
            //public string[] Parse(IHtmlDocument document)
            //{
            //    if (document == null) { Log.Warning("Пустой документ"); return Array.Empty<string>(); }

            //    var list = new List<string>();
            //    //сюда копируем часть после class="Вот это всё будем выбирать и парсить"
            //    var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("iva-item-body-oMJBI"));
            //    var alternativeItems = document.QuerySelectorAll("a[data-marker='item-title']");
            //    var resultItems = items.Any() ? items : alternativeItems;

            //    foreach (var item in items)
            //    {
            //        string text = item.TextContent?.Trim();
            //        if (string.IsNullOrEmpty(text)) { list.Add(item.TextContent); }
            //    }
            //    if (list.Count == 0) { Log.Warning("Пусто, возможно обновилась вёрстка сайта"); }

            //    return list.ToArray();
            //}

    }
}