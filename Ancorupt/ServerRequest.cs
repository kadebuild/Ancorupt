using SimpleJSON;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace Ancorupt
{
    static class ServerRequest
    {
        private static readonly string serverUrl = "http://yourServerURL.ru/";
        private static string SessionId { get; set; }

        // Основной метод осуществляющий передачу данных от клиента к серверу
        private static JSONNode Send(string url, NameValueCollection param, string method = "POST")
        {
            byte[] response;
            try
            {
                using (WebClient client = new WebClient())
                {
                    response = client.UploadValues(url, method, param);
                }
                return JSON.Parse(Encoding.UTF8.GetString(response));
            } catch (Exception) { return false; }
        }

        /// <summary>
        /// Вход в учетную запись
        /// </summary>
        /// <param name="email">Email адрес учетной записи</param>
        /// <param name="password">Пароль от учетной записи</param>
        /// <returns>Возвращает JSON ответ от сервера</returns>
        public static JSONNode Login(string email, string password)
        {
            NameValueCollection param = new NameValueCollection
            {
                { "email", email },
                { "password", password }
            };
            return Send(serverUrl + "login.php", param);
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="email">Email адрес учетной записи</param>
        /// <param name="password">Пароль от учетной записи</param>
        /// <returns>Возвращает JSON ответ от сервера</returns>
        public static JSONNode Registration(string email, string password)
        {
            NameValueCollection param = new NameValueCollection
            {
                { "email", email },
                { "password", password }
            };
            return Send(serverUrl + "registration.php", param);
        }

        /// <summary>
        /// Купить лицензионный ключ на текущую учетную запись
        /// </summary>
        /// <returns>Возвращает JSON ответ от сервера</returns>
        public static JSONNode Buy()
        {
            NameValueCollection param = new NameValueCollection
            {
                { "session", SessionId }
            };
            return Send(serverUrl + "buy.php", param);
        }

        /// <summary>
        /// Восстановить лицензионный ключ, купленный на текущую учетную запись
        /// </summary>
        /// <returns>Возвращает JSON ответ от сервера</returns>
        public static JSONNode Recover()
        {
            NameValueCollection param = new NameValueCollection
            {
                { "session", SessionId }
            };
            return Send(serverUrl + "recover.php", param);
        }

        /// <summary>
        /// Привязать ключ к текущему компьютеру
        /// </summary>
        /// <param name="key">Лицензионный ключ программы</param>
        /// <returns>Возвращает JSON ответ от сервера</returns>
        public static JSONNode Attach(string key)
        {
            NameValueCollection param = new NameValueCollection
            {
                { "disk", SystemInfoHelper.Disk() },
                { "cpu", SystemInfoHelper.Cpu() },
                { "baseboard", SystemInfoHelper.BaseBoard() },
                { "bios", SystemInfoHelper.Bios() },
                { "key", key },
                { "session", SessionId }
            };
            return Send(serverUrl + "attach.php", param);
        }

        /// <summary>
        /// Установить Id сессии
        /// </summary>
        /// <param name="session">Id сессии</param>
        public static void SetSessionId(string session)
        {
            SessionId = session;
        }

        /// <summary>
        /// Метод позволяет узнать вошел ли пользователь в учетную запись.
        /// </summary>
        /// <returns>Результат true - если пользователь вошел в учетную запись, false - если нет</returns>
        public static bool Logged()
        {
            return !string.IsNullOrEmpty(SessionId);
        }
    }
}
