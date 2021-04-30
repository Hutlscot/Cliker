namespace Cliker.Logic
{
    using System.Net;

    using Cliker.Model;
    using Cliker.Model.ValuesForHeaders;

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
                client.DownloadString(Links.Home);

                GetCookie(client);
            }
        }

        /// <summary>
        /// получить клиент для запросов
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
        /// добавить заголовки в запрос
        /// </summary>
        /// <param name="client">веб клиент</param>
        private static void SetHeaders(this WebClient client)
        {
            client.Headers.Add(HttpRequestHeader.Accept, ValuesForHeaders.Accept);
            client.Headers.Add(HttpRequestHeader.AcceptEncoding, ValuesForHeaders.Accept_Encoding);
            client.Headers.Add(HttpRequestHeader.AcceptLanguage, ValuesForHeaders.Accept_Language);
            client.Headers.Add(HttpRequestHeader.CacheControl, ValuesForHeaders.Cache_Control);
            client.Headers.Add(HttpRequestHeader.Host, ValuesForHeaders.Host);
            client.Headers.Add("sec-ch-ua", ValuesForHeaders.Sec_Ch_UA);
            client.Headers.Add("sec-ch-ua-mobile", ValuesForHeaders.Sec_Ch_UA_Modile);
            client.Headers.Add("Sec-Fetch-Dest", ValuesForHeaders.Sec_Fetch_Dest);
            client.Headers.Add("Sec-Fetch-Mode", ValuesForHeaders.Sec_Fetch_Mode);
            client.Headers.Add("Sec-Fetch-Site", ValuesForHeaders.Sec_Fetch_Site);
            client.Headers.Add("Sec-Fetch-User", ValuesForHeaders.Sec_Fetch_User);
            client.Headers.Add("Upgrade-Insecure-Requests", ValuesForHeaders.Upgrade_Insecure_Requests);
            client.Headers.Add(HttpRequestHeader.UserAgent, ValuesForHeaders.UserAgent);
        }

        /// <summary>
        /// добавить куки в запрос
        /// </summary>
        /// <param name="client">веб клиент</param>
        private static void SetCookie(this WebClient client)
        {
            client.Headers.Add(HttpRequestHeader.Cookie, _cookie);   
        }

        private static void GetCookie(WebClientCookies client)
        {
            _cookie += client.ResponseCookies["uidc"]+"; ";
            _cookie += client.ResponseCookies["PHPSESSID"] + ";";
        }
    }
}