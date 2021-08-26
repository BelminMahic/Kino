using MobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            viewModel = new LoginViewModel(Navigation);

            BindingContext = viewModel;

        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            var control = sender as Entry;

            if (control.IsPassword)
            {
                viewModel.CheckPasswordErrors();
            }
            else
            {
                viewModel.CheckUsernameErrors();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            UsernameEntry.Unfocused -= Entry_Unfocused;
            PasswordEntry.Unfocused -= Entry_Unfocused;
        }
    }
}