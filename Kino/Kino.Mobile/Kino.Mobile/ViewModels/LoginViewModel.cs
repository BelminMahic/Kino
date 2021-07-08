using Kino.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kino.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private readonly APIService _apiService = new APIService("user");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login() );
        }


        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            IsBusy = true;
            //APIService.Username = Username;
            //APIService.Password = Password;
            try
            {
                await _apiService.Get<dynamic>(null);
                Application.Current.MainPage = new AboutPage();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
