namespace UI.Model
{
    /// <summary>
    /// Данные о периодах атак на арену.
    /// </summary>
    public class PeriodForArena
    {
        public PeriodForArena(string title, int time)
        {
            Title = title;
            Time = time;
        }

        /// <summary>
        /// Время для ожидания.
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Title { get; set; }
    }
}