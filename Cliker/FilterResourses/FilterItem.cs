namespace Cliker.FilterResourses
{
    /// <summary>
    /// Класс элемента фильтра
    /// </summary>
    public class FilterItem
    {
        /// <summary>
        /// Название элемента фильтра
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Статус включенности
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// Создать элемент фильтра
        /// </summary>
        public FilterItem(string name)
        {
            Name = name;
            IsEnable = false;
        }
    }
}