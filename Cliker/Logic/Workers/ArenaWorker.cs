﻿namespace Cliker.Logic.Workers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Media;

    using AngleSharp.Html.Parser;

    using global::Cliker.Logic.Loggers;
    using global::Cliker.Logic.Parser;
    using global::Cliker.Logic.ToolsForQuery;
    using global::Cliker.Logic.Utility;
    using global::Cliker.Model;

    /// <summary>
    /// Класс для работы с ареной
    /// </summary>
    public class ArenaWorker
    {
        /// <summary>
        /// Флаг вкл или выкл
        /// </summary>
        private bool isOn;

        /// <summary>
        /// Начать кликать арену.
        /// </summary>
        /// <param name="time">Периодичность атак арены</param>
        public Task Start(int time, ArenaLogger arenaLogger)
        {
            isOn = true;
            return Task.Run(
                () =>
                {
                    using (var client = RequestWorker.GetClient())
                    {
                        while (true)
                        {
                            if (!isOn)
                                return;

                            var responses = new List<string>();
                            while (WorkerUtils.CheckHealth(client) && WorkerUtils.CheckMana(client))
                            {
                                var url = GetUrlForAttack(client);
                                responses.Add(Attack(client, url));
                            }

                            arenaLogger.ParseSeriesAttack(responses);

                            Console.WriteLine($"Ушел в сон на {time} секунд");
                            Thread.Sleep(time);
                        }
                    }
                });
        }

        /// <summary>
        /// Получить ссылку для атаки
        /// </summary>
        /// <param name="client">ВебКлиента</param>
        /// <returns>Ссылка для атаки строкой</returns>
        private string GetUrlForAttack(WebClient client)
        {
            var parser = new TiwarParser();
            var domParser = new HtmlParser();

            var response = Encoding.UTF8.GetString(client.DownloadData(Links.Arena));
            var document = domParser.ParseDocumentAsync(response, new CancellationToken());

            var result = parser.SearchLink(document.Result, "Атаковать").FirstOrDefault();
            var url = $"{Links.Home}{result}";

            return url;
        }

        /// <summary>
        /// Произвести атаку
        /// </summary>
        /// <param name="client">ВебКлиента</param>
        /// <param name="url">Ссылка для атаки</param>
        /// <returns>Страница ответ после атаки</returns>
        private string Attack(WebClient client, string url)
        {
            return Encoding.UTF8.GetString(client.DownloadData(url));
        }

        /// <summary>
        /// Остановиться кликать арену.
        /// </summary>
        public void Stop()
        {
            isOn = false;
        }
    }
}