﻿using Kino.Desktop.UI.Auditorium;
using Kino.Desktop.UI.Cinema;
using Kino.Desktop.UI.City;
using Kino.Desktop.UI.Country;
using Kino.Desktop.UI.Genre;
using Kino.Desktop.UI.Movie;
using Kino.Desktop.UI.MovieSeat;
using Kino.Desktop.UI.Profile;
using Kino.Desktop.UI.PromoMaterial;
using Kino.Desktop.UI.Reports;
using Kino.Desktop.UI.Reservation;
using Kino.Desktop.UI.SeatReservation;
using Kino.Desktop.UI.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Reservation
{
    public partial class frm_ReservationDetails : Form
    {

        private readonly APIService _cinemaService = new APIService("cinema");
        private readonly APIService _movieService = new APIService("movie");
        private readonly APIService _auditoriumService = new APIService("auditorium");

        public frm_ReservationDetails()
        {
            InitializeComponent();
        }

        private async void frm_ReservationDetails_Load(object sender, EventArgs e)
        {
            await LoadCinemas();
            await LoadAuditoriums();
            await LoadMovies();
        }

        private async Task LoadCinemas()
        {
            var result = await _cinemaService.Get<List<Model.Cinema>>(null);
            result.Insert(0, new Model.Cinema());
            cb_Kina.DisplayMember = "CinemaName";
            cb_Kina.ValueMember = "CinemaId";
            cb_Kina.DataSource = result;
        }
        private async Task LoadAuditoriums()
        {
            var result = await _auditoriumService.Get<List<Model.Auditorium>>(null);
            result.Insert(0, new Model.Auditorium());
            cb_Dvorana.DisplayMember = "AuditoriumName";
            cb_Dvorana.ValueMember = "AuditoriumId";
            cb_Dvorana.DataSource = result;
        }

        private async Task LoadMovies()
        {
            var result = await _movieService.Get<List<Model.Movie>>(null);
            result.Insert(0, new Model.Movie());
            cb_Film.DisplayMember = "MovieName";
            cb_Film.ValueMember = "MovieId";
            cb_Film.DataSource = result;
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

        private void btnProfile_Click(object sender, EventArgs e)
        {
            frm_UserProfile frm = new frm_UserProfile();
            frm.Show();
        }

        private void btnKina_Click(object sender, EventArgs e)
        {
            frm_CinemaDetails frm = new frm_CinemaDetails();
            frm.Show();
        }
    }
}
