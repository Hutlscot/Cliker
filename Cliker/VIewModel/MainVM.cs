namespace Cliker
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows;

    using Cliker.Logic.Command;
    using Cliker.Model;
    using Cliker.Model.FilterResourses;

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
            LoadFilterItems();
        }

        /// <summary>
        /// Список элементов фильтра
        /// </summary>
        public List<FilterItem> FilterItems { get; set; }

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
        /// Подгрузить элементы фильтра
        /// </summary>
        private void LoadFilterItems()
        {
            var filter = new Filter();
            FilterItems = filter.GetFilterItems();
        }
    }
}