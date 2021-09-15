using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Helpers
{
    public static class Settings
    {
        public static string text = "http://localhost:32958/api";

#if DEBUG
        public static string ApiUrl = "http://localhost:8001/api";

#endif

        private static ISettings AppSettings => CrossSettings.Current;

        public static int UserId
        {
            get => AppSettings.GetValueOrDefault(nameof(UserId), 0);
            set => AppSettings.AddOrUpdateValue(nameof(UserId), value);
        }

        public static string Username
        {
            get => AppSettings.GetValueOrDefault(nameof(Username), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Username), value);
        }

        public static string Password
        {
            get => AppSettings.GetValueOrDefault(nameof(Password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Password), value);
        }

        public static void SaveUser(int userId, string username, string password)
        {
            UserId = userId;
            Username = username;
            Password = password;
        }
    }
}
