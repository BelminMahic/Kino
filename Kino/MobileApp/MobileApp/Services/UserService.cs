using MobileApp.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class UserService
    {
        public async Task<ServiceRequestStatus> Login(string email, string password)
        {
            var httpClient = new HttpClient();

            var jsonString = @"{ ""email"" : """ + email
                + @""" , ""password"" : """ + password
                + @""", ""returnSecureToken"" : """ + true
                + @""" } ";

            var contentBody = new StringContent(jsonString, Encoding.UTF8, "application/json");


            /*var response = await httpClient.PostAsync(_firebaseApiUrl + ":signInWithPassword?key=AIzaSyAMshVxCMGLj811FMGUzC6dEv-0UR4Oplc", contentBody);

            if (response.IsSuccessStatusCode)
            {
                var session = JsonConvert.DeserializeObject<Session>(response.Content.ReadAsStringAsync().Result);

                AuthService.SetSession(session);

                return ServiceRequestStatus.RequestSuccess;
            }

            var jsonObject = JObject.Parse(await response.Content.ReadAsStringAsync());
            var error = jsonObject["error"]["message"].ToString();

            switch (error)
            {
                case "EMAIL_NOT_FOUND":
                    return ServiceRequestStatus.EmailNotFound;
                case "INVALID_PASSWORD":
                    return ServiceRequestStatus.InvalidPassword;
                case "USER_DISABLED":
                    return ServiceRequestStatus.UserDisabled;
                default:
                    return ServiceRequestStatus.ServerError;
            }*/

            return ServiceRequestStatus.EmailNotFound;
        }
    }
}
