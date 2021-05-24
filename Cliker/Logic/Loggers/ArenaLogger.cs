namespace Cliker.Logic.Loggers
{
    using System.Collections.Generic;
    using System.Windows.Documents;

    /// <summary>
    /// Логгер арены
    /// </summary>
    public class ArenaLogger
    {
        /// <summary>
        /// Хранит лог данных
        /// </summary>
        public string Log { get; set; }

        /// <summary>
        /// Обработать серию атак.
        /// </summary>
        /// <param name="responses">Страницы ответы после атак</param>
        /// <returns>Exp, серебро, и кол-во атак за последнюю серию</returns>
        public void ParseSeriesAttack(List<string> responses)
        {
            Log =  "Вы добыли: exp:{exp}, серебро: {silver}, кол-во атак:{count}";
        }
    }
}