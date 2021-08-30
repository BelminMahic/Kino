using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Movie
{
    public partial class frm_MovieFullDetails : Form
    {
        private readonly APIService _movieService = new APIService("movie");
        private readonly APIService _genreService = new APIService("genre");
        private readonly APIService _cinemaService = new APIService("cinema");

        private int? _movieId = null;

        public frm_MovieFullDetails(int? movieId = null)
        {
            InitializeComponent();
            _movieId = movieId;
        }
        MovieUpsertRequest request = new MovieUpsertRequest();

        private async void frm_MovieFullDetails_Load(object sender, EventArgs e)
        {
            try
            {
                if (_movieId.HasValue)
                {
                    var movie = await _movieService.GetById<Model.Movie>(_movieId);

                    txtNazivFilma.Text = movie.MovieName;
                    txtOriginal.Text = movie.OriginalMovieName;
                    txtDatumPrikazivanja.Text = movie.ShowTime.ToString();
                    txtGlumci.Text = movie.ActorsName;
                    txt_Reditelj.Text = movie.DirectorFullName;
                    txtTrajanje.Text = movie.MovieDuration;
                    txtOpis.Text = movie.Description;
                    picturePoster.Image = ByteToImage(movie.MoviePoster);
                }


                await LoadGenres();
                await LoadCinemas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Film", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                request.MovieName = txtNazivFilma.Text;
                request.OriginalMovieName = txtOriginal.Text;
                request.DirectorFullName = txt_Reditelj.Text;
                request.ActorsName = txtGlumci.Text;
                request.CinemaId = int.Parse(cb_Kino.SelectedValue.ToString());
                request.GenreId = int.Parse(cb_Zanrovi.SelectedValue.ToString());
                request.Description = txtOpis.Text;
                request.MovieDuration = txtTrajanje.Text;
                request.ShowTime = DateTime.Parse(txtDatumPrikazivanja.Text);
                request.MoviePoster = ConvertImageToBytes(picturePoster.Image);


                if (_movieId.HasValue)
                {
                    await _movieService.Update<Model.Movie>(_movieId, request);
                }

                MessageBox.Show("Izmjena uspjesno odradjena!");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Film", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private static byte[] ConvertImageToBytes(Image image)
        {
            if (image != null)
            {
                MemoryStream ms = new MemoryStream();
                using (ms)
                {
                    image.Save(ms, ImageFormat.Bmp);
                    ms.Position = 0;
                    byte[] bytes = ms.ToArray();

                    return bytes;
                }
            }
            else
            {
                return null;
            }
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
