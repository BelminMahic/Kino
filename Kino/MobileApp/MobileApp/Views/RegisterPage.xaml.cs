using MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        RegisterViewModel viewModel;

        public RegisterPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            viewModel = new RegisterViewModel(Navigation);
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.InitializeData().ConfigureAwait(false);
        }
    }
}