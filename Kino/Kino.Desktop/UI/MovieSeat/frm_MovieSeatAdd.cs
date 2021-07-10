using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.Desktop.UI.MovieSeat
{
    public partial class frm_MovieSeatAdd : Form
    {

        private readonly APIService _movieSeatService = new APIService("movieseat");
        private readonly APIService _auditoriumService = new APIService("auditorium");


        public frm_MovieSeatAdd()
        {
            InitializeComponent();
        }

        private void txtMovieSeatRow_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMovieSeatRow.Text))
            {
                errorProvider.SetError(txtMovieSeatRow, "Red sjedista je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtMovieSeatRow, null);

            }
        }

        private void txtRowNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRowNumber.Text))
            {
                errorProvider.SetError(txtRowNumber, "Broj rednog sjedista je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtRowNumber, null);

            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren()) { 
            var request = new MovieSeatUpsertRequest
            {
                MovieSeatRow = txtMovieSeatRow.Text,
                RowNumber = int.Parse(txtRowNumber.Text),
                AuditoriumId =int.Parse(cb_Auditorium.SelectedValue.ToString())
            };

            await _movieSeatService.Insert<Model.MovieSeat>(request);
            MessageBox.Show("Uspjesno dodano!");
            }
        }

        private async void frm_MovieSeatAdd_Load(object sender, EventArgs e)
        {
            await LoadAuditoriums();
        }

        private async Task LoadAuditoriums()
        {
            var result = await _auditoriumService.Get<List<Model.Auditorium>>(null);
            result.Insert(0, new Model.Auditorium());
            cb_Auditorium.DataSource = result;
            cb_Auditorium.DisplayMember = "AuditoriumName";
            cb_Auditorium.ValueMember = "AuditoriumId";

        }
    }
}
