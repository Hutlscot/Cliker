namespace Cliker.Logic.Utility
{
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Windows;

    using AngleSharp.Html.Parser;

    using global::Cliker.Logic.Parser;
    using global::Cliker.Model;

    /// <summary>
    /// Класс работникам
    /// </summary>
    public static class WorkerUtils
    {
        /// <summary>
        /// Метод проверки здоровья
        /// </summary>
        /// <returns>true если хватает, false если не хватает</returns>
        public static bool CheckHealth(WebClient client)
        {
            var parser = new TiwarParser();
            var domParser = new HtmlParser();

            var response = Encoding.UTF8.GetString(client.DownloadData(Links.Arena));
            var document = domParser.ParseDocumentAsync(response, new CancellationToken());

            var result = parser.FindHealthValue(document.Result).FirstOrDefault();
            return true;
        }

        /// <summary>
        /// Метод проверки маны
        /// </summary>
        /// <returns>true если хватает, false если не хватает</returns>
        public static bool CheckMana(WebClient client)
        {
            return true;
        }
    }
}