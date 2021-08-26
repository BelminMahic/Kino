using MobileApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Services
{
    public static class LogoutService
    {
        public static void Logout()
        {
            Settings.Password = string.Empty;
            Settings.UserId = 0;
            Settings.Username = string.Empty;
        }
    }
}
