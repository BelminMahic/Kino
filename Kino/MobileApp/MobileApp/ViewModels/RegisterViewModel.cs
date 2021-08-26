using Kino.Model;
using Kino.Model.Requests;
using MobileApp.Utils;
using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("user");
        private readonly APIService _genderService = new APIService("gender");

        private string _firstname;

        private string _lastname;

        private string _email;

        private string _phone;

        private string _username;

        private string _password;

        private bool? _status;

        private Gender _selectedGender;

        private ObservableCollection<Gender> _genders;

        private readonly INavigation _navigation;

        public RegisterViewModel(INavigation navigation)
        {
            _navigation = navigation;
            RegisterCommand = new Command(async () => await ExecuteRegisterCommand().ConfigureAwait(false));
        }

        public string Firstname
        {
            get
            {
                return _firstname;
            }

            set
            {
                SetProperty(ref _firstname, value);
            }
        }

        public string Lastname
        {
            get
            {
                return _lastname;
            }

            set
            {
                SetProperty(ref _lastname, value);
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                SetProperty(ref _email, value);
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                SetProperty(ref _phone, value);
            }
        }


        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                SetProperty(ref _username, value);
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
                SetProperty(ref _password, value);
            }
        }

        public bool? Status
        {
            get
            {
                return _status;
            }

            set
            {
                SetProperty(ref _status, value);
            }
        }

        public Gender SelectedGender
        {
            get
            {
                return _selectedGender;
            }

            set
            {
                SetProperty(ref _selectedGender, value);
            }
        }

        public ObservableCollection<Gender> Genders
        {
            get
            {
                return _genders;
            }

            set
            {
                SetProperty(ref _genders, value);
            }
        }

        public ICommand RegisterCommand { get; private set; }

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(Firstname) || String.IsNullOrEmpty(Lastname) || String.IsNullOrEmpty(Email) 
                || !RegexUtilities.IsValidEmail(Email)
                || String.IsNullOrEmpty(Phone) || String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password) 
                || SelectedGender == null)
            {
                return false;
            }

            return true;
        }

        public async Task InitializeData()
        {
            try
            {
                Genders = new ObservableCollection<Gender>();
                Genders = await _genderService.Get<ObservableCollection<Gender>>(null);
                SelectedGender = Genders?.FirstOrDefault();
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Greska!",
                                                                "Doslo je do greske u komunikaciji sa serverom. Pokusajte kasnije.",
                                                                "OK");
            }
        }

        private async Task ExecuteRegisterCommand()
        {
            if (!IsValid())
            {
                await Application.Current.MainPage.DisplayAlert("Greska!",
                                                                "Molimo unesite sva polja oznacena kao obavezna i provjerite da li je format emaila validan.",
                                                                "OK");
                return;
            }

            try
            {
                var request = new UserUpsertRequest
                {
                    Email = Email,
                    Name = Firstname,
                    UserName = Lastname,
                    Password = Password,
                    PasswordConfirmation = Password,
                    LastName = Lastname,
                    Phone = Phone,
                    GenderId = SelectedGender?.GenderId ?? 0
                };

                User entity = null;
                entity = await _service.Insert<User>(request);

                if (entity != null)
                {
                    await Application.Current.MainPage.DisplayAlert("",
                                                                    "Uspjesno dodano!",
                                                                    "OK");

                    await NavigationService.NavigateWithStackReset(_navigation,new NavigationPage(new MoviesListPage()));
                }
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Greska!",
                                                                    "Doslo je do greske prilikom registracije. Pokusajte ponovo.",
                                                                    "OK");
            }
        }
    }
}
