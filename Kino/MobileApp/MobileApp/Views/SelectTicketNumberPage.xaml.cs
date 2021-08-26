using MobileApp.Helpers;
using MobileApp.Services;
using MobileApp.Utils;
using MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectTicketNumberPage : ContentPage
    {
        SelectTicketNumberViewModel viewModel;
        public SelectTicketNumberPage(Models.Movie movie, Kino.Model.Cinema cinema, Models.Screening screening)
        {
            InitializeComponent();

            viewModel = new SelectTicketNumberViewModel(movie, cinema, screening);

            BindingContext = viewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var reservation = new Models.Reservation
            {
                AuditoriumId = viewModel.Screening.AuditoriumId,
                Screening = viewModel.Screening,
                ScreeningId = viewModel.Screening.ScreeningId,
                Quantity = viewModel.TicketNumber,
                UserId = Settings.UserId,
                Cinema = viewModel.Cinema,
            };
            await Navigation.PushAsync(new SelectSeatPage(reservation));
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