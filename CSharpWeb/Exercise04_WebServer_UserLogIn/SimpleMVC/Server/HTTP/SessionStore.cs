

using System.Collections.Concurrent;
using System.Text;

namespace SimpleMVC.Server.HTTP
{
    public static class SessionStore
    {
        public const string SessionCookieKey = "MY_SID";
        //public const string CurrentUserKey = "^%Current_User_Session_Key%^";

        private static readonly ConcurrentDictionary<string, HttpSession> sessions =
            new ConcurrentDictionary<string, HttpSession>();

        public static HttpSession Get(string id)
        {
            return sessions.GetOrAdd(id, _ => new HttpSession(id));
        }

        public static void DeleteSession(string id)
        {
            sessions.TryRemove(id, out HttpSession session);
        }

        public static string GetSesions()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var session in sessions)
            {
                sb.AppendLine($"ID: {session.Key} {session.Value.IsLoggedIn().ToString()}");
            }

            return sb.ToString();
        }
           
    }
}
