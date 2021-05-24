namespace Cliker.Logic
{
    using System.Security;

    using global::Cliker.Logic.Loggers;
    using global::Cliker.Logic.Workers;
    using global::Cliker.Model;

    /// <summary>
    /// Класс логики кликера
    /// </summary>
    public class Cliker
    {
        /// <summary>
        /// Инструмент работы с ареной
        /// </summary>
        private ArenaWorker arenaWorker;

        /// <summary>
        /// Инструмент работы с пещерой
        /// </summary>
        private CaveWorker caveWorker;

        /// <summary>
        /// Инструмент работы с походом
        /// </summary>
        private WalkWorker walkWorker;

        /// <summary>
        /// Инструмент работы с клан. монстром
        /// </summary>
        private MonsterWorker monsterWorker;

        /// <summary>
        /// Инициализация кликера
        /// </summary>
        public Cliker()
        {
            arenaWorker = new ArenaWorker();
            caveWorker = new CaveWorker();
            walkWorker = new WalkWorker();
            monsterWorker = new MonsterWorker();
        }

        /// <summary>
        /// Метод запуска кликера
        /// </summary>
        /// <param name="period">Переодичность атак арены</param>
        public void Start(PeriodForArena period, ArenaLogger arenaLogger)
        {
            arenaWorker.Start(period.Time, arenaLogger);
            //caveWorker.Start();
            //walkWorker.Start();
            //monsterWorker.Start();
        }

        /// <summary>
        /// Метод остановки кликера
        /// </summary>
        public void Stop()
        {
            arenaWorker.Stop();
            caveWorker.Stop();
            walkWorker.Stop();
            monsterWorker.Stop();

        }
    }
}