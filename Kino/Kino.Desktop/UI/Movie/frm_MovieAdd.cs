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
            if (this.ValidateChildren()) { 
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

        private void txtNazivFilma_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivFilma.Text))
            {
                errorProvider.SetError(txtNazivFilma, "Naziv filma je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtNazivFilma, null);

            }
        }

        private void txtOriginal_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOriginal.Text))
            {
                errorProvider.SetError(txtOriginal, "Originalni naziv filma je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtOriginal, null);

            }
        }

        private void txt_Reditelj_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Reditelj.Text))
            {
                errorProvider.SetError(txt_Reditelj, "Naziv reditelja je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txt_Reditelj, null);

            }
        }

        private void txtGlumci_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGlumci.Text))
            {
                errorProvider.SetError(txtGlumci, "Naziv glumaca je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtGlumci, null);

            }
        }

        private void txtTrajanje_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrajanje.Text))
            {
                errorProvider.SetError(txtTrajanje, "Trajanje filma je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTrajanje, null);
            }
        }

        private void txtDatumPrikazivanja_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDatumPrikazivanja.Text))
            {
                errorProvider.SetError(txtDatumPrikazivanja, "Datum prikazivanja je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtDatumPrikazivanja, null);

            }
        }

        private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                errorProvider.SetError(txtOpis, "Opis filma je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtOpis, null);

            }
        }
    }
}
