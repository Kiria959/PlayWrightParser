using ParserDopolneniy.Core;
using ParserDopolneniy.Core.ParcimSaiti;
using Serilog;

namespace ParserDopolneniy
{
    public partial class Form1 : Form
    {
        private ParserWorker<string[]> parser;

        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(
                new SitesParcer()
                );

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;

        }
        private void Parser_OnNewData(object arg1, string[] arg2)
        {

            if (ListTitles.InvokeRequired) { ListTitles.Invoke(new Action(() => ListTitles.Items.AddRange(arg2))); }
            else { ListTitles.Items.AddRange(arg2); };
        }

        private void Parser_OnCompleted(object obj)
        {
            this.Invoke(new Action(() => { ButtonStart.Enabled = true; }));
            MessageBox.Show("Работает)");
        }


        private async void ButtonStart_Click(object sender, EventArgs e)
        {
            parser.Settings = new SitesSettings((int)NumericStart.Value, (int)NumericEnd.Value, headless: false);
            ButtonStart.Enabled = false;
            try
            {
                await parser.StartAsync();
            }
            catch (Exception ex)
            {
                Log.Warning("Ошибка при запуске парсера");
                ButtonStart.Enabled = true;
            }
        }

        private void ButtonAbort_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }

        private void ListTitles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
