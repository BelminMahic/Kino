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
    }
}
