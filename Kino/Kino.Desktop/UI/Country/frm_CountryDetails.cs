using Kino.Desktop.UI.Auditorium;
using Kino.Desktop.UI.Cinema;
using Kino.Desktop.UI.City;
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

namespace Kino.Desktop.UI.Country
{
    public partial class frm_CountryDetails : Form
    {
        private readonly APIService _aPIService = new APIService("country");

        public frm_CountryDetails()
        {
            InitializeComponent();
        }
              

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {



                var search = new CountrySearchRequest()
                {
                    CountryName = txtSearch.Text
                };
                var result = await _aPIService.Get<List<Model.Country>>(search);

                dgv_Drzave.DataSource = result;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Drzava", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_Drzave_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var id = dgv_Drzave.SelectedRows[0].Cells[0].Value;
                frm_CountryFullDetails frm = new frm_CountryFullDetails(int.Parse(id.ToString()));
                frm.Show();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Drzava", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frm_CountryAdd frm = new frm_CountryAdd();
            frm.Show();
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
