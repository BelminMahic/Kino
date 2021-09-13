using Kino.Desktop.UI.Auditorium;
using Kino.Desktop.UI.Cinema;
using Kino.Desktop.UI.City;
using Kino.Desktop.UI.Country;
using Kino.Desktop.UI.Genre;
using Kino.Desktop.UI.Movie;
using Kino.Desktop.UI.MovieSeat;
using Kino.Desktop.UI.PromoMaterial;
using Kino.Desktop.UI.Reports;
using Kino.Desktop.UI.SeatReservation;
using Kino.Desktop.UI.User;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Reservation
{
    public partial class frm_ReservationDetails : Form
    {

        private readonly APIService _screeningService = new APIService("screening");
        private readonly APIService _auditoriumService = new APIService("auditorium");
        private readonly APIService _reservationService = new APIService("reservation");


        public frm_ReservationDetails()
        {
            InitializeComponent();
        }

        private async void frm_ReservationDetails_Load(object sender, EventArgs e)
        {
            await LoadScreenings();
            await LoadAuditoriums();
        }

        private async Task LoadScreenings()
        {
            var result = await _screeningService.Get<List<Model.Screening>>(null);
            result.Insert(0, new Model.Screening());
            cb_Prikazivanja.DisplayMember = "ScreeningStart";
            cb_Prikazivanja.ValueMember = "ScreeningId";
            cb_Prikazivanja.DataSource = result;
        }
        private async Task LoadAuditoriums()
        {
            var result = await _auditoriumService.Get<List<Model.Auditorium>>(null);
            result.Insert(0, new Model.Auditorium());
            cb_Dvorana.DisplayMember = "AuditoriumName";
            cb_Dvorana.ValueMember = "AuditoriumId";
            cb_Dvorana.DataSource = result;
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
                var request = new ReservationSearchRequest()
                {
                    AuditoriumId= int.Parse(cb_Dvorana.SelectedValue.ToString()),
                    ScreeningId = int.Parse(cb_Prikazivanja.SelectedValue.ToString())
                    
                };
                request.IncludeList = new string[]
               {
                    "Auditorium",
                    "Screening"
               };
              


                var reservations = await _reservationService.Get<List<Model.Reservation>>(request);
                dgv_Rezervacije.DataSource = reservations;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Rezervacije", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
