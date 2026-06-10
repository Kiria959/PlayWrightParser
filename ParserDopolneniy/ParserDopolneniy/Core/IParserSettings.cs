using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserDopolneniy.Core
{
    internal interface IParserSettings
    {
        string BaseUrl { get; set; }

        string Prefix { get; set; }

        int StartPoint { get; set; }

        int EndPoint { get; set; }

        bool Headless { get; set; }

        string GetUrlForPage(int pageId);
    }
}
