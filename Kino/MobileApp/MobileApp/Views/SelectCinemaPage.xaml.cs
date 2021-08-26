using MobileApp.Services;
using MobileApp.Utils;
using MobileApp.ViewModels;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectCinemaPage : ContentPage
    {
        SelectCinemaViewModel viewModel;

        public SelectCinemaPage(ObservableCollection<Models.Screening> screenings, Models.Movie movie)
        {
            InitializeComponent();

            viewModel = new SelectCinemaViewModel(screenings, movie);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.InitializeData();
            Device.BeginInvokeOnMainThread(() =>
            {
                BindingContext = viewModel;
            });
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewModel.SelectedCinema == null || viewModel.SelectedDate == DateTime.MinValue)
            {
                return;
            }

            viewModel.SetShowTimes();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            viewModel.SelectedTime = (DateTime)btn.BindingContext;
            var screening = viewModel.GetScreening();
            await Navigation.PushAsync(new SelectTicketNumberPage(viewModel.Movie, viewModel.SelectedCinema, screening));
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