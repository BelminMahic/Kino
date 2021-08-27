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
    public partial class MovieDetailsPage : ContentPage
    {
        MovieDetailsViewModel viewModel;
        public MovieDetailsPage(Movie movie)
        {
            InitializeComponent();

            viewModel = new MovieDetailsViewModel(movie);

            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.InitializeData().ConfigureAwait(false);

            Device.BeginInvokeOnMainThread(() =>
            {
                BindingContext = viewModel;
            });
            
        }

        private async void BuyTicket_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectCinemaPage(viewModel.GetAllScreenings(), viewModel.Movie));
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            LogoutService.Logout();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await NavigationService.NavigateWithStackReset(Navigation, new LoginPage());
            });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await viewModel.SaveRating().ConfigureAwait(false);
        }
    }
}