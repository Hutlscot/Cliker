namespace Cliker
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Threading;
    using System.Windows;

    using AngleSharp.Html.Parser;

    using Cliker.Logic;
    using Cliker.Logic.Command;
    using Cliker.Logic.Loggers;
    using Cliker.Logic.Parser;
    using Cliker.Logic.ToolsForQuery;
    using Cliker.Model;
    using Cliker.Model.FilterResourses;

    /// <summary>
    /// Вьюмодель главного окна
    /// </summary>
    public class MainVM
    {
        /// <summary>
        /// Сам кликер
        /// </summary>
        private readonly Cliker _cliker;

        public ArenaLogger ArenaLogger { get; set; }

        /// <summary>
        /// Список элементов фильтра
        /// </summary>
        public List<FilterItem> FilterItems { get; set; }

        /// <summary>
        /// Список доступных периодов
        /// </summary>
        public List<PeriodForArena> Periods { get; set; } = new List<PeriodForArena>();

        /// <summary>
        /// Инициализация VM
        /// </summary>
        public MainVM()
        {
            LoadDataOnForm();
            _cliker = new Cliker();
            ArenaLogger = new ArenaLogger();
        }

        /// <summary>
        /// Команда авторизации
        /// </summary>
        public MainCommand LoginCommand
        {
            get
            {
                return new MainCommand(
                    obj =>
                    {
                        Process.Start(Links.Home);
                        MessageBox.Show("Выполните вход в браузере\nвход здесь пока не реализован");
                    });
            }
        }

        /// <summary>
        /// Команда начала работы кликера
        /// </summary>
        public MainCommand StartCommand
        {
            get
            {
                return new MainCommand(
                    obj =>
                    {
                        _cliker.Start(obj as PeriodForArena, ArenaLogger);
                    });
            }
        }

        public MainCommand StopCommand
        {
            get
            {
                return new MainCommand(
                    obj =>
                    {
                        _cliker.Stop();
                    });
            }
        }

        /// <summary>
        /// Подгрузить элементы фильтра
        /// </summary>
        private void LoadDataOnForm()
        {
            var filter = new Filter();
            FilterItems = filter.GetFilterItems();

            Periods.Add(new PeriodForArena("10 минут", 600000));
            Periods.Add(new PeriodForArena("20 минут", 1200000));
            Periods.Add(new PeriodForArena("30 минут", 1800000));
        }
    }
}