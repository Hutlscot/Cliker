namespace Cliker.Logic.ToolsForQuery
{
    using System.Net;

    using global::Cliker.Model;
    using global::Cliker.Model.ValuesForHeaders;

    /// <summary>
    /// инстурумент для выполнения запросов
    /// </summary>
    public static class RequestWorker
    {
        /// <summary>
        /// куки необходимые для запросов
        /// </summary>
        private static string _cookie;

        /// <summary>
        /// Подготовить инструмент, получить куки
        /// </summary>
        static RequestWorker()
        {
            using (var client = new WebClientCookies())
            {
                client.SetHeaders();
                var response = client.DownloadString(Links.Home);

                SetCookie(client);
            }
        }

        /// <summary>
        /// получить клиента для запросов
        /// </summary>
        /// <returns></returns>
        public static WebClient GetClient()
        {
            using (var client = new WebClient())
            {
                client.SetHeaders();
                client.SetCookie();

                return client;
            }
        }

        /// <summary>
        /// задать стандартные куки для всех запросов
        /// </summary>
        /// <param name="client">веб клиент</param>
        private static void SetCookie(WebClientCookies client)
        {
            //_cookie += client.ResponseCookies["PHPSESSID"] + "; ";
            _cookie += "PHPSESSID=175b66d1f19afba0a614725ed31240e9;";
            _cookie += "_ym_uid=161978143880128752; _ym_d=1619781438; _ym_isad=2; _ym_visorc=w";
        }

        /// <summary>
        /// добавить куки в запрос
        /// </summary>
        /// <param name="client">веб клиент</param>
        private static void SetCookie(this WebClient client)
        {
            client.Headers.Add(HttpRequestHeader.Cookie, _cookie);
        }

        /// <summary>
        /// добавить заголовки в запрос
        /// </summary>
        /// <param name="client">веб клиент</param>
        private static void SetHeaders(this WebClient client)
        {
            client.Headers.Add(HttpRequestHeader.Accept, ValuesForHeaders.Accept);
            client.Headers.Add(HttpRequestHeader.AcceptLanguage, ValuesForHeaders.Accept_Language);
            client.Headers.Add(HttpRequestHeader.CacheControl, ValuesForHeaders.Cache_Control);
            client.Headers.Add(HttpRequestHeader.Host, ValuesForHeaders.Host);
            client.Headers.Add("Upgrade-Insecure-Requests", ValuesForHeaders.Upgrade_Insecure_Requests);
            client.Headers.Add(HttpRequestHeader.UserAgent, ValuesForHeaders.UserAgent);
        }
    }
}