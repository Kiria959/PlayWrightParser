using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserDopolneniy.Core.ParcimSaiti
{
    internal class SitesSettings : IParserSettings
    {

        public SitesSettings(int start, int end, bool headless = false)
        {
            StartPoint = start;
            EndPoint = end;
            Headless = headless;
        }
        //Ccылку сюда пихат 
        public string BaseUrl { get; set; } = "https://www.avito.ru/krasnodarskiy_kray/kvartiry/prodam-ASgBAgICAUSSA8YQ";
        public string Prefix { get; set; } = "context=H4sIAAAAAAAA_wEtANL_YToxOntzOjg6ImZyb21QYWdlIjtzOjE2OiJzZWFyY2hGb3JtV2lkZ2V0Ijt9F_yIfi0AAAA&f=ASgBAQICAUSSA8YQAUDgwt3NAiSA6Q~C6Q8";
        //с какого элеменка начинаем
        public int StartPoint { get; set; }
        //каким кончаем
        public int EndPoint { get; set; }
        public bool Headless { get; set; }

        public string GetUrlForPage(int pageId)
        {
            return $"{BaseUrl}?p={pageId}&{Prefix}";
        }
    }
}
