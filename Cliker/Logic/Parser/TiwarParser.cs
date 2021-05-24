namespace Cliker.Logic.Parser
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Documents;

    using AngleSharp.Html.Dom;

    /// <summary>
    /// Класс-парсер html  документа
    /// </summary>
    public class TiwarParser
    {
        /// <summary>
        /// Ищет ссылку в документе с кнопки
        /// </summary>
        /// <param name="document">Документ страницы</param>
        /// <param name="btmContent">Контент кнопки</param>
        /// <returns>Ссылка из кнопки</returns>
        public string[] SearchLink(IHtmlDocument document, string btmContent)
        {
            var result = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.TextContent.Contains(btmContent));

            foreach (var item in items)
            {
                result.Add(item.GetAttribute("href"));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Ищет значение здоровья в документе
        /// </summary>
        /// <param name="document">Документ страницы</param>
        /// <returns>Значение здоровья</returns>
        public string[] FindHealthValue(IHtmlDocument document)
        {
            var result = new List<string>();
            var items = document.QuerySelectorAll("span").Where(item => item.ClassName?.Contains("white") == true);

            foreach (var item in items)
            {
                result.Add(item.TextContent);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Ищет значение маны в документе
        /// </summary>
        /// <param name="document">Документ страницы</param>
        /// <returns>Значение маны</returns>
        private string[] FindManaValue(IHtmlDocument document)
        {
            var result = new List<string>();
            //var items = document.QuerySelectorAll("span").Where(item => item.ClassName?.Contains("white") == true);

            //foreach (var item in items)
            //{
            //    result.Add(item.TextContent);
            //}

            return result.ToArray();
        }
    }
}