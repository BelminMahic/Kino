using MobileApp.Helpers;
using MobileApp.Utils;
using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("user");

        private string _username;

        private string _password;

        private string _usernameErrorText;

        private string _passwordErrorText;

        private readonly INavigation _navigation;

        public LoginViewModel(INavigation navigation)
        {
            Title = "Login";
            _navigation = navigation;
            LoginCommand = new Command(async () => await ExecuteLoginCommand().ConfigureAwait(false));
            OpenRegistrationPageCommand = new Command(async () => await ExecuteOpenRegistrationPageCommand().ConfigureAwait(false));
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string UsernameErrorText
        {
            get
            {
                return _usernameErrorText;
            }

            set
            {
                _usernameErrorText = value;
                OnPropertyChanged();
            }
        }

        public string PasswordErrorText
        {
            get
            {
                return _passwordErrorText;
            }

            set
            {
                _passwordErrorText = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; private set; }

        public ICommand OpenRegistrationPageCommand { get; private set; }

        public async Task ExecuteLoginCommand()
        {
            APIService.UserName = Username;
            APIService.Password = Password;

            if (!CheckUsernameErrors())
                return;

            if (!CheckPasswordErrors())
                return;

            try
            {
                var users = await _service.Get<List<Kino.Model.User>>(null);

                if(users != null)
                {
                    var user = users.FirstOrDefault(x => x.UserName == Username);
                    Settings.SaveUser(user.UserId, Username, Password);

                    await NavigationService.NavigateWithStackReset(_navigation, new MoviesListPage()).ConfigureAwait(false);
                }
                else
                {
                    await DisplayErrorDialog().ConfigureAwait(false);
                }
            }
            catch
            {
                await DisplayErrorDialog().ConfigureAwait(false);
            }
        }

        public async Task ExecuteOpenRegistrationPageCommand()
        {
            await _navigation.PushAsync(new RegisterPage());
        }

        public bool CheckUsernameErrors()
        {
            if (String.IsNullOrEmpty(Username))
            {
                UsernameErrorText = "Korisnicko ime je obavezno!";
                return false;
            }
            else
            {
                UsernameErrorText = string.Empty;
                return true;
            }
        }

        public bool CheckPasswordErrors()
        {
            if (String.IsNullOrEmpty(Password))
            {
                PasswordErrorText = "Lozinka je obavezna!";
                return false;
            }
            else
            {
                PasswordErrorText = string.Empty;
                return true;
            }
        }

        private async Task DisplayErrorDialog()
        {
            await Application.Current.MainPage.DisplayAlert("Greska!",
                                                            "Pogresno korisnicko ime i/ili lozinka.",
                                                            "OK");
        }
    }
}
