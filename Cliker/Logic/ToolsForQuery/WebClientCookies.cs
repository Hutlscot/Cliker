namespace Cliker.Logic
{
    using System;
    using System.Net;

    public class WebClientCookies : WebClient
    {
        public WebClientCookies()
        {
            CookieContainer = new CookieContainer();
            ResponseCookies = new CookieCollection();
        }

        private CookieContainer CookieContainer { get; }

        public CookieCollection ResponseCookies { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.CookieContainer = CookieContainer;
            return request;
        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            var response = (HttpWebResponse)base.GetWebResponse(request);
            ResponseCookies = response.Cookies;
            return response;
        }
    }
}