using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using Kino.Model;
using MobileApp.Helpers;

namespace MobileApp
{
    public class APIService
    {
        private string _route = null;
        public static string UserName { get; set; }
        public static string Password { get; set; }

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {

            var url = $"{Settings.ApiUrl}/{_route}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            if (string.IsNullOrEmpty(UserName)){
                UserName = Settings.Username;
            }

            if (string.IsNullOrEmpty(Password))
            {
                Password = Settings.Password;
            }

            var result = await url.WithBasicAuth(UserName,Password).GetJsonAsync<T>();

            return result;

        }
        public async Task<T> GetById<T>(object id)
        {

            var url = $"{Settings.ApiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(UserName, Password).GetJsonAsync<T>();

        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Settings.ApiUrl}/{_route}";

            return await url.WithBasicAuth(UserName, Password).PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{Settings.ApiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(UserName, Password).PutJsonAsync(request).ReceiveJson<T>();
        }
    }
}
