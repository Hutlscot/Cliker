namespace Cliker.Logic
{
    using System.Collections.Specialized;
    using System.Text;
    using System.Windows;

    using Cliker.Logic.ToolsForQuery;
    using Cliker.Model;

    /// <summary>
    /// класс для авторизации
    /// еще не рабочий
    /// </summary>
    public class Authorization
    {
        private User User { get; set; }

        public void LoginIn()
        {
            var login = "Мойперс";
            var pass = "Farcry";

            User = new User(login, pass);
            const string Url = "http://tiwar.ru/";

            var data = new NameValueCollection();

            data.Add("name", login);
            data.Add("Password", pass);
            using (var client = RequestWorker.GetClient())
            {
                client.Headers.Set("Content-Length", "60");
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var result = client.UploadValues(Url, "POST", data);
                var header = client.ResponseHeaders;
                var s = Encoding.UTF8.GetString(result);

                MessageBox.Show(s);
                MessageBox.Show(header.ToString());
            }
        }
    }
}