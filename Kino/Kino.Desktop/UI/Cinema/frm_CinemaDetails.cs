using Kino.Desktop.UI.Auditorium;
using Kino.Desktop.UI.City;
using Kino.Desktop.UI.Country;
using Kino.Desktop.UI.Genre;
using Kino.Desktop.UI.Movie;
using Kino.Desktop.UI.MovieSeat;
using Kino.Desktop.UI.PromoMaterial;
using Kino.Desktop.UI.Reports;
using Kino.Desktop.UI.Reservation;
using Kino.Desktop.UI.SeatReservation;
using Kino.Desktop.UI.User;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Cinema
{
    public partial class frm_CinemaDetails : Form
    {

        private readonly APIService _apiService = new APIService("cinema");

        public frm_CinemaDetails()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frm_CinemaAdd frm = new frm_CinemaAdd();
            frm.Show();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                var search = new CinemaSearchRequest
                {
                    CinemaName = txtSearch.Text
                };
                search.IncludeList = new string[]
                 {
                    "City"
                 };

                var result = await _apiService.Get<List<Model.Cinema>>(search);

                dgv_Kina.DataSource = result;
                this.dgv_Kina.Columns["CityId"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kino", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_Kina_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {

                var id = dgv_Kina.SelectedRows[0].Cells[0].Value;
                frm_CinemaFullDetails frm = new frm_CinemaFullDetails(int.Parse(id.ToString()));
                frm.Show();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kino", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
