using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Auditorium
{



    public partial class frm_AuditoriumFullDetails : Form
    {

        private readonly APIService _audService = new APIService("auditorium");
        private readonly APIService _cinService = new APIService("cinema");
        private readonly int? _auditoriumId = null;

        public frm_AuditoriumFullDetails(int? id = null)
        {
            InitializeComponent();
            _auditoriumId = id;

        }

        private async void frm_AuditoriumFullDetails_Load(object sender, EventArgs e)
        {
            if (_auditoriumId.HasValue)
            {
                var auditorium = await _audService.GetById<Model.Auditorium>(_auditoriumId);

                txtNazivDvorane.Text = auditorium.AuditoriumName;
                txtBrojSjedista.Text = auditorium.SeatNumbers.ToString();

            }
            await LoadCinemas();
        }

        private async Task LoadCinemas()
        {
            var result = await _cinService.Get<List<Model.Cinema>>(null);
            result.Insert(0, new Model.Cinema());
            cb_Kina.DataSource = result;
            cb_Kina.DisplayMember = "CinemaName";
            cb_Kina.ValueMember = "CinemaId";

        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                var request = new AuditoriumUpsertRequest()
                {
                    AuditoriumName = txtNazivDvorane.Text,
                    SeatNumbers = int.Parse(txtBrojSjedista.Text),
                    CinemaId = int.Parse(cb_Kina.SelectedValue.ToString())
                };
                if (_auditoriumId.HasValue)
                {
                    await _audService.Update<Model.Auditorium>(_auditoriumId, request);
                }

                MessageBox.Show("Izmjena uspjesno odradjena!");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Dvorana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
    }
}
