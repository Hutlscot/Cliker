namespace Cliker.Model
{
    /// <summary>
    /// класс пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// логин пользователя
        /// </summary>
        private readonly string _login;

        /// <summary>
        /// пароль пользователя
        /// </summary>
        private readonly string _pass;

        /// <summary>
        /// создание пользователя
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="pass">пароль</param>
        public User(string login, string pass)
        {
            _login = login;
            _pass = pass;
        }

        /// <summary>
        /// логин пользователя
        /// </summary>
        public string Login => _login;

        /// <summary>
        /// пароль пользователя
        /// </summary>
        public string Password => _pass;
    }
}