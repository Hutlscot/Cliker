namespace Cliker.Model.FilterResourses
{
    using System.Collections.Generic;

    /// <summary>
    /// класс фильтра
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Список элементов фильтра
        /// </summary>
        private readonly List<FilterItem> Items;

        /// <summary>
        /// Создать фильтр
        /// </summary>
        public Filter()
        {
            Items = InitializeFilterItems();
        }

        /// <summary>
        /// Получить элементы фильтра
        /// </summary>
        /// <returns>Список элементов фильтра</returns>
        public List<FilterItem> GetFilterItems()
        {
            return Items;
        }

        /// <summary>
        /// Создать элементы фильтра
        /// </summary>
        private List<FilterItem> InitializeFilterItems()
        {
            var listItems = new List<FilterItem>();
            listItems.Add(new FilterItem("Обсидиан"));
            listItems.Add(new FilterItem("Оникс"));
            listItems.Add(new FilterItem("Графит"));
            return listItems;
        }
    }
}