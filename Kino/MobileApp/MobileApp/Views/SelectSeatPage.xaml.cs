using MobileApp.Services;
using MobileApp.Utils;
using MobileApp.ViewModels;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectSeatPage : ContentPage
    {
        SelectSeatViewModel viewModel;

        public SelectSeatPage(Models.Reservation reservation)
        {
            InitializeComponent();

            viewModel = new SelectSeatViewModel(reservation);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.InitializeData().ConfigureAwait(false);

            GenerateView();
        }


        private void GenerateView()
        {
            Grid grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                }
            };

            var seats = (viewModel.MovieSeats.Count / 8);
            var totalRows = seats + 1;
            var seatsInLastRow = viewModel.MovieSeats.Count - (seats * 8);

            var seatCounter = 0;
            for (int i = 0; i < totalRows; i++)
            {
                if (i != 0)
                {
                    seatCounter++;
                }
                grid.RowDefinitions.Add(new RowDefinition());

                for (int j = 0; j < 8; j++)
                {
                    if (j != 0)
                    {
                        seatCounter++;
                    }
                    // if this is last row which can have less than 8 seats (columns)
                    // then create columns only for available seats
                    if (i == totalRows - 1 && j >= seatsInLastRow)
                    {
                        break;
                    }

                    var currentSeat = viewModel.MovieSeats?.ElementAt(seatCounter);

                    var button = new Button
                    {
                        WidthRequest = 30,
                        HeightRequest = 30,
                        BackgroundColor = Color.SkyBlue,
                        BindingContext = currentSeat,
                        IsEnabled = !viewModel.IsSeatReserved(currentSeat.MovieSeatId),
                    };

                    button.Clicked += OnButtonClicked;
                    grid.Children.Add(button, j, i);
                }
            }

            Device.BeginInvokeOnMainThread(() =>
            {
                contentStackView.Children.Add(grid);
            });
            
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var movieSeat = btn.BindingContext as Kino.Model.MovieSeat;

            if (viewModel.ReservedSeats?.Count == viewModel.Reservation.Quantity)
            {
                await Application.Current.MainPage.DisplayAlert("Greska!",
                                                            "Broj odabranih sjedista ne moze biti veci od broja odabranih karata.",
                                                            "OK");
                return;
            }

            if (viewModel.IsSeatTaken(movieSeat.MovieSeatId))
            {
                viewModel.RemoveItemFromReservedSeates(movieSeat);
                btn.BackgroundColor = Color.SkyBlue;
            }
            else
            {
                viewModel.AddItemToReservedSeates(movieSeat);

                btn.BackgroundColor = Color.DarkBlue;
            }
        }

        private async void ContinueButton_Clicked(object sender, EventArgs e)
        {
            // broj odabranih sjedista ne smije biti 0 niti manji/veci od broja odabranih karata
            if (viewModel.ReservedSeats?.Count == 0 || viewModel.ReservedSeats.Count != viewModel.Reservation.Quantity)
            {
                await Application.Current.MainPage.DisplayAlert("Greska!",
                                                            "Molimo odaberite isti broj mjesta kao i broj karata.",
                                                            "OK");
                return;
            }
            await Navigation.PushAsync(new ConfirmReservationPage(viewModel.Reservation, viewModel.ReservedSeats));
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