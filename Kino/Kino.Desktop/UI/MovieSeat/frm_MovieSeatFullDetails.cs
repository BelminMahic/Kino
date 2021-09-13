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
    public partial class frm_MovieSeatFullDetails : Form
    {

        private readonly APIService _movieSeatService = new APIService("movieseat");
        private readonly APIService _audService = new APIService("auditorium");

        private int? _msId = null;


        public frm_MovieSeatFullDetails(int? msId = null)
        {
            InitializeComponent();
            _msId = msId;
        }

        private async void frm_MovieSeatFullDetails_Load(object sender, EventArgs e)
        {
            try
            {
                if (_msId.HasValue)
                {
                    var seat = await _movieSeatService.GetById<Model.MovieSeat>(_msId);

                    txtMovieSeatRow.Text = seat.MovieSeatRow;
                    txtRowNumber.Text = seat.RowNumber.ToString();


                 
                }


                await LoadAuditoriums();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sjediste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





       

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new MovieSeatUpsertRequest()
                {
                    MovieSeatRow = txtMovieSeatRow.Text,
                    RowNumber = int.Parse(txtRowNumber.Text),
                    AuditoriumId = int.Parse(cb_Auditorium.SelectedValue.ToString())
                };
                if (_msId.HasValue)
                {
                    await _movieSeatService.Update<Model.MovieSeat>(_msId, request);
                }

                MessageBox.Show("Izmjena uspjesno odradjena!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sjediste", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task LoadAuditoriums()
        {
            var result = await _audService.Get<List<Model.Auditorium>>(null);
            result.Insert(0, new Model.Auditorium());
            cb_Auditorium.DisplayMember = "AuditoriumName";
            cb_Auditorium.ValueMember = "AuditoriumId";
            cb_Auditorium.DataSource = result;
        }
    }
}
