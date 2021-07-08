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
    public partial class frm_AuditoriumAdd : Form
    {

        private readonly APIService _audService = new APIService("auditorium");
        private readonly APIService _cinService = new APIService("cinema");

        public frm_AuditoriumAdd()
        {
            InitializeComponent();
        }
        private async void frm_AuditoriumAdd_Load(object sender, EventArgs e)
        {
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = new AuditoriumUpsertRequest
            {
                AuditoriumName = txtNazivDvorane.Text,
                SeatNumbers = int.Parse(txtBrojSjedista.Text),
                CinemaId = int.Parse(cb_Kina.SelectedValue.ToString())
            };
            await _audService.Insert<Model.Auditorium>(request);
            MessageBox.Show("Dodavanje uspjesno odradjeno!");
        }
    }
}
