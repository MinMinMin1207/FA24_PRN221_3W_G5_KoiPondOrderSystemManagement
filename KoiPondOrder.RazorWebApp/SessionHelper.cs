using KoiPondOrderSystemManagement.Repositories.Models;
using System.Text.Json;

namespace KoiPondOrderSystemManagement.RazorWebApp
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }

        public static User GetLoginAccount(this ISession session, string key)
        {
            return GetObjectFromJson<User>(session, key);
        }

    }
}
