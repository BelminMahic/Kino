using MobileApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class ConfirmReservationViewModel : BaseViewModel
    {
        private readonly APIService _reservationService = new APIService("reservation");
        private readonly APIService _seatReservationService = new APIService("seatreservation");
        private Models.Reservation _reservation;
        private List<Kino.Model.MovieSeat> _reservedMovieSeats;

        public ConfirmReservationViewModel(Models.Reservation reservation, List<Kino.Model.MovieSeat> reservedMovieSeats)
        {
            _reservation = reservation;
            _reservedMovieSeats = reservedMovieSeats;
        }

        public Models.Reservation Reservation
        {
            get
            {
                return _reservation;
            }
            set
            {
                SetProperty(ref _reservation, value);
            }
        }

        public List<Kino.Model.MovieSeat> ReservedMovieSeats
        {
            get
            {
                return _reservedMovieSeats;
            }
            set
            {
                SetProperty(ref _reservedMovieSeats, value);
            }
        }

        public async Task<bool> CreateReservation()
        {
            try
            {
                var reservationObject = new Kino.Model.Reservation
                {
                    ScreeningId = _reservation.ScreeningId,
                    AuditoriumId = _reservation.AuditoriumId,
                    Quantity = _reservation.Quantity,
                    ReservationDate = DateTime.Now,
                    UserId = Settings.UserId,
                };
                var reservation = await _reservationService.Insert<Models.Reservation>(reservationObject);

                if (reservation == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Greska",
                                                                    "Doslo je do greske. Molimo pokusajte ponovo.",
                                                                    "OK");
                    return false;
                }
                foreach(var seat in _reservedMovieSeats)
                {
                    var newSeatReservation = new Kino.Model.SeatReservation
                    {
                        MovieSeatId = seat.MovieSeatId,
                        ReservationId = reservation.ReservationId,
                        ScreeningId = reservation.ScreeningId,
                    };
                    var reservedSeat = await _seatReservationService.Insert<Kino.Model.SeatReservation>(newSeatReservation);

                    if (reservedSeat == null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Greska",
                                                                    "Doslo je do greske. Molimo pokusajte ponovo.",
                                                                    "OK");
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Greska",
                                                                    "Doslo je do greske. Molimo pokusajte ponovo.",
                                                                    "OK");
                return false;
            }
        }
    }
}
