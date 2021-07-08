using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Movie
{
    public partial class frm_MovieAdd : Form
    {

        private readonly APIService _movieService = new APIService("movie");
        private readonly APIService _genreService = new APIService("genre");
        private readonly APIService _cinemaService = new APIService("cinema");

        public frm_MovieAdd()
        {
            InitializeComponent();
        }
        MovieUpsertRequest request = new MovieUpsertRequest();

       

        private async void frm_MovieAdd_Load(object sender, EventArgs e)
        {
            await LoadGenres();
            await LoadCinemas();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var genreIdObj = cb_Zanrovi.SelectedValue;
            if (int.TryParse(genreIdObj.ToString(), out int genreId))
            {
                request.GenreId = genreId;
            }
            var cinemaIdObj = cb_Kino.SelectedValue;
            if (int.TryParse(cinemaIdObj.ToString(), out int cinemaId))
            {
                request.CinemaId = cinemaId;
            }

            request.MovieName = txtNazivFilma.Text;
            request.OriginalMovieName = txtOriginal.Text;
            request.DirectorFullName = txt_Reditelj.Text;
            request.MovieDuration = txtTrajanje.Text;
            request.ActorsName = txtGlumci.Text;
            request.Description = txtOpis.Text;
            request.ShowTime = DateTime.Parse(txtDatumPrikazivanja.Text);



            await _movieService.Insert<Model.Movie>(request);

            MessageBox.Show("Film uspjesno dodan!");
        }






        private async Task LoadGenres()
        {
            var result = await _genreService.Get<List<Model.Genre>>(null);
            result.Insert(0, new Model.Genre());
            cb_Zanrovi.DisplayMember = "GenreName";
            cb_Zanrovi.ValueMember = "GenreId";
            cb_Zanrovi.DataSource = result;
        }

        private async Task LoadCinemas()
        {
            var result = await _cinemaService.Get<List<Model.Cinema>>(null);
            result.Insert(0, new Model.Cinema());
            cb_Kino.DisplayMember = "CinemaName";
            cb_Kino.ValueMember = "CinemaId";
            cb_Kino.DataSource = result;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;

                var file = File.ReadAllBytes(filename);

                request.MoviePoster = file;

                Image image = Image.FromFile(filename);
                picturePoster.Image = image;
            }
        }
    }
}
