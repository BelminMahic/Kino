using MobileApp.Models;
using MobileApp.Services;
using MobileApp.Utils;
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
    public partial class MoviesListPage : ContentPage
    {
        MoviesListViewModel viewModel;

        public MoviesListPage()
        {
            InitializeComponent();

            viewModel = new MoviesListViewModel();

            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.InitializeData().ConfigureAwait(false);
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Movie;

            await Navigation.PushAsync(new MovieDetailsPage(item));
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            LogoutService.Logout();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await NavigationService.NavigateWithStackReset(Navigation, new LoginPage());
            });
        }
    }
}