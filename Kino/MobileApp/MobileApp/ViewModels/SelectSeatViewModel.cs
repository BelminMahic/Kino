using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class SelectSeatViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("seatreservation");
        private readonly APIService _movieSeatService = new APIService("movieseat");
        private Models.Reservation _reservation;

        private List<Kino.Model.SeatReservation> _seatReservations;

        private List<Kino.Model.MovieSeat> _movieSeats;

        private List<Kino.Model.MovieSeat> _reservedSeats;

        public SelectSeatViewModel(Models.Reservation reservation)
        {
            _reservation = reservation;
            _reservedSeats = new List<Kino.Model.MovieSeat>();
        }

        public List<Kino.Model.MovieSeat> ReservedSeats
        {
            get
            {
                return _reservedSeats;
            }

            set
            {
                SetProperty(ref _reservedSeats, value);
            }
        }

        public List<Kino.Model.MovieSeat> MovieSeats
        {
            get
            {
                return _movieSeats;
            }

            set
            {
                SetProperty(ref _movieSeats, value);
            }
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

        public async Task InitializeData()
        {
            try
            {
                _seatReservations = await _service.Get<List<Kino.Model.SeatReservation>>(new SeatReservationSearchRequest { ScreeningId = _reservation.ScreeningId });
                _movieSeats = await _movieSeatService.Get<List<Kino.Model.MovieSeat>>(new MovieSeatUpsertRequest { AuditoriumId = _reservation.AuditoriumId });
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Greska!",
                                                            "Doslo je do greske. Pokusajte kasnije.",
                                                            "OK");
            }

        }

        public bool IsSeatReserved(int movieSeatId)
        {
            return _seatReservations.Any(x => x.MovieSeatId == movieSeatId);
        }

        public void AddItemToReservedSeates(Kino.Model.MovieSeat movieSeat)
        {
            if(_reservedSeats == null)
            {
                _reservedSeats = new List<Kino.Model.MovieSeat>();
            }

            _reservedSeats.Add(movieSeat);
        }

        public void RemoveItemFromReservedSeates(Kino.Model.MovieSeat movieSeat)
        {
            if (_reservedSeats == null)
            {
                return;
            }

            _reservedSeats.Remove(movieSeat);
        }

        public bool IsSeatTaken(int movieSeatId)
        {
            return _reservedSeats.Any(x => x.MovieSeatId == movieSeatId);
        }
    }
}
