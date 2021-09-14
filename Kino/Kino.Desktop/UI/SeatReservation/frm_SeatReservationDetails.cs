using Kino.Desktop.UI.Auditorium;
using Kino.Desktop.UI.Cinema;
using Kino.Desktop.UI.City;
using Kino.Desktop.UI.Country;
using Kino.Desktop.UI.Genre;
using Kino.Desktop.UI.Movie;
using Kino.Desktop.UI.MovieSeat;
using Kino.Desktop.UI.PromoMaterial;
using Kino.Desktop.UI.Reports;
using Kino.Desktop.UI.Reservation;
using Kino.Desktop.UI.User;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.Desktop.UI.SeatReservation
{
    public partial class frm_SeatReservationDetails : Form
    {

        private readonly APIService _seatReservationService = new APIService("seatreservation");
        private readonly APIService _reservationService = new APIService("reservation");
        private readonly APIService _screeningService = new APIService("screening");
        private readonly APIService _movieSeatService = new APIService("movieSeat");



        public frm_SeatReservationDetails()
        {
            InitializeComponent();
        }


        private async void frm_SeatReservationDetails_Load(object sender, EventArgs e)
        {
            await LoadMovieSeats();
            await LoadReservations();
            await LoadScreenings();
        }


        private void btnFilmovi_Click(object sender, EventArgs e)
        {
            frm_MovieDetails frm = new frm_MovieDetails();
            frm.Show();
        }

        private void btnDvorane_Click(object sender, EventArgs e)
        {
            frm_AuditoriumDetails frm = new frm_AuditoriumDetails();
            frm.Show();
        }

        private void btnSeatReservation_Click(object sender, EventArgs e)
        {
            frm_SeatReservationDetails frm = new frm_SeatReservationDetails();
            frm.Show();
        }

        private void btnSjedista_Click(object sender, EventArgs e)
        {
            frm_MovieSeatDetails frm = new frm_MovieSeatDetails();
            frm.Show();
        }

        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            frm_ReservationDetails frm = new frm_ReservationDetails();
            frm.Show();
        }

        private void btnZanrovi_Click(object sender, EventArgs e)
        {
            frm_GenreDetails frm = new frm_GenreDetails();
            frm.Show();
        }

        private void btnGradovi_Click(object sender, EventArgs e)
        {
            frm_CityDetails frm = new frm_CityDetails();
            frm.Show();
        }

        private void btnDrzave_Click(object sender, EventArgs e)
        {
            frm_CountryDetails frm = new frm_CountryDetails();
            frm.Show();
        }

        private void btnPromo_Click(object sender, EventArgs e)
        {
            frm_PromoDetails frm = new frm_PromoDetails();
            frm.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frm_UserDetails frm = new frm_UserDetails();
            frm.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frm_Reports frm = new frm_Reports();
            frm.Show();
        }

      

        private void btnKina_Click(object sender, EventArgs e)
        {
            frm_CinemaDetails frm = new frm_CinemaDetails();
            frm.Show();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new SeatReservationSearchRequest
                {
                    MovieSeatId = int.Parse(cbSjediste.SelectedValue.ToString()),
                    ReservationId = int.Parse(cbRezervacija.SelectedValue.ToString()),
                    ScreeningId = int.Parse(cbScreening.SelectedValue.ToString())
                };
                request.IncludeList = new string[]
                {
                    "MovieSeat",
                    "Reservation",
                    "Screening"
                };

                var seatReservs = await _seatReservationService.Get<List<Model.SeatReservation>>(request);
                dgv_SeatReservation.DataSource = seatReservs;
                this.dgv_SeatReservation.Columns["Reservation"].Visible = false;
                this.dgv_SeatReservation.Columns["ReservationId"].Visible = false;
                this.dgv_SeatReservation.Columns["Screening"].Visible = false;
                this.dgv_SeatReservation.Columns["ScreeningId"].Visible = false;
                this.dgv_SeatReservation.Columns["MovieSeatId"].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Rezervacija sjedista", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async Task LoadReservations()
        {
            var result = await _reservationService.Get<List<Model.Reservation>>(null);
            result.Insert(0, new Model.Reservation());
            cbRezervacija.DisplayMember = "ReservationDate";
            cbRezervacija.ValueMember = "ReservationId";
            cbRezervacija.DataSource = result;
        }

        private async Task LoadScreenings()
        {
            var result = await _screeningService.Get<List<Model.Screening>>(null);
            result.Insert(0, new Model.Screening());
            cbScreening.DisplayMember = "ScreeningStart";
            cbScreening.ValueMember = "ScreeningId";
            cbScreening.DataSource = result;
        }
        private async Task LoadMovieSeats()
        {
            var result = await _movieSeatService.Get<List<Model.MovieSeat>>(null);
            result.Insert(0, new Model.MovieSeat());
            cbSjediste.DisplayMember = "MovieSeatRow";
            cbSjediste.ValueMember = "MovieSeatId";
            cbSjediste.DataSource = result;
        }

        
    }
}
