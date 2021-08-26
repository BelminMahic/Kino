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
    public partial class ConfirmReservationPage : ContentPage
    {
        ConfirmReservationViewModel viewModel;

        public ConfirmReservationPage(Models.Reservation reservation, List<Kino.Model.MovieSeat> selectedSeats)
        {
            InitializeComponent();

            viewModel = new ConfirmReservationViewModel(reservation, selectedSeats);

            BindingContext = viewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var isCreated = await viewModel.CreateReservation().ConfigureAwait(false);

            if (isCreated)
            {
                Device.BeginInvokeOnMainThread(async() => {
                    await NavigationService.NavigateWithStackReset(Navigation, new MoviesListPage());
                });
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            LogoutService.Logout();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await NavigationService.NavigateWithStackReset(Navigation,new LoginPage());
            });
        }
    }
}