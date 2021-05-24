namespace Cliker.Model
{
    /// <summary>
    /// Данные о периодах атак на арену.
    /// </summary>
    public class PeriodForArena
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Время для ожидания.
        /// </summary>
        public int Time { get; set; }

        public PeriodForArena(string title, int time)
        {
            Title = title;
            Time = time;
        }
    }
}