using AngleSharp.Html.Parser;
using ParserDopolneniy.Core.Parser.Core;
using Serilog;

namespace ParserDopolneniy.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;

        HtmlLoader loader;
        bool isActive;

        #region Properties
        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }
        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }



        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }
        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
            loader = new HtmlLoader(parserSettings);
        }

        public async Task StartAsync()
        {
            if (isActive) { Log.Warning("Уже работает"); return; };
            isActive = true;
            await Worker();
        }

        public void Abort()
        {
            isActive = false;
        }

        private async Task Worker()
        {
            try
            {

                await loader.InitializeAsync();
                var domParcer = new HtmlParser();

                for (int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
                {
                    if (!isActive)
                    {
                        OnCompleted?.Invoke(this);
                        return;
                    }
                    //грузим наш документ
                    var source = await loader.GetSourseByPageId(i);
                    if (string.IsNullOrEmpty(source)) { continue; }

                    //парсим 
                    var document = await domParcer.ParseDocumentAsync(source);
                    //парсим ещё раз по нашим настройкам
                    var result = parser.Parse(document);
                    if (result != null) { OnNewData?.Invoke(this, result); }
                    else { return; }

                    
                }

            }
            catch (Exception ex)
            {
                Log.Error("Ошибка Воркера");
                throw;
            }
            finally
            {
                if (loader != null) { await loader.DisposeAsync(); }
                OnCompleted?.Invoke(this);
                isActive = false;
            }

        }
    }
}
