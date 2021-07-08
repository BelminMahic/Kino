using System.Threading.Tasks;
using Flurl.Http;
using Kino.Model;
namespace Kino.Mobile
{
    public class APIService
    {
        private string _route = null;

#if DEBUG
        private string _apiURL = "http://localhost:32958/api";
#endif
#if RELEASE
        private string _apiURL = "http://mywebsite.com/api";

#endif


        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {

            var url = $"{_apiURL}/{_route}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }
            var result = await url.GetJsonAsync<T>();

            return result;

        }
        public async Task<T> GetById<T>(object id)
        {

            var url = $"{_apiURL}/{_route}/{id}";

            return await url.GetJsonAsync<T>();

        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiURL}/{_route}";

            return await url.PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{_apiURL}/{_route}/{id}";

            return await url.PutJsonAsync(request).ReceiveJson<T>();
        }
    }
}
//Application.Current.MainPage.DisplayAlert("Greska","Niste autentificirani","OK"); // za exception