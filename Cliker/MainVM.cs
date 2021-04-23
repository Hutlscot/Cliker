﻿namespace Cliker
{
    using System.Collections.Generic;

    using Cliker.FilterResourses;

    /// <summary>
    /// Вьюмодель главного окна
    /// </summary>
    public class MainVM
    {
        /// <summary>
        /// Список элементов фильтра
        /// </summary>
        public List<FilterItem> FilterItems { get; set; }

        /// <summary>
        /// Инициализация VM
        /// </summary>
        public MainVM()
        {
            LoadFilterItems();
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