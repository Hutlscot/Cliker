namespace UI.ViewModel
{
    using System.Collections.Generic;
    using System.Windows;

    using UI.Command;
    using UI.Model;
    using UI.Model.FilterResourses;

    /// <summary>
    /// Вьюмодель главного окна
    /// </summary>
    public class MainVM
    {
        /// <summary>
        /// Инициализация VM
        /// </summary>
        public MainVM()
        {
            LoadDataOnForm();
        }

        /// <summary>
        /// Список элементов фильтра
        /// </summary>
        public List<FilterItem> FilterItems { get; set; }

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
                        //Process.Start(Links.HOME);
                        MessageBox.Show("Выполните вход в браузере\nвход здесь пока не реализован");
                    });
            }
        }

        /// <summary>
        /// Список доступных периодов
        /// </summary>
        public List<PeriodForArena> Periods { get; set; } = new List<PeriodForArena>();

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
                        //_cliker.Start(obj as PeriodForArena);
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
                        //_cliker.Stop();
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