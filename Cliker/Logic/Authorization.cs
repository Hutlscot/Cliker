namespace Cliker.Logic
{
    using System.Collections.Specialized;
    using System.Net;
    using System.Windows;

    using Cliker.Model.ValuesForHeaders;

    public class Authorization
    {
        private User User { get; set; }
        public void LoginIn()
        {
            var login = "Testinggg";
            var pass = "Testinggg";

            User = new User(login, pass);
            const string Url = "https://mrush.mobi/welcome";

            var reqparm = new NameValueCollection();
            

            reqparm.Add("name", login);
            reqparm.Add("Password", pass);
            using (var client = RequestWorker.GetClient())
            {
                var response = client.DownloadString(Url);

                var headers = client.ResponseHeaders["Set-Cookie"];

                MessageBox.Show(headers);
                MessageBox.Show(response);
               
            }

           
        }
    }
}