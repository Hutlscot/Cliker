namespace UI.Model.FilterResourses
{
    /// <summary>
    /// Класс элемента фильтра
    /// </summary>
    public class FilterItem
    {
        /// <summary>
        /// Создать элемент фильтра
        /// </summary>
        public FilterItem(string name)
        {
            Name = name;
            IsEnable = false;
        }

        /// <summary>
        /// Статус включенности
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// Название элемента фильтра
        /// </summary>
        public string Name { get; }
    }
}