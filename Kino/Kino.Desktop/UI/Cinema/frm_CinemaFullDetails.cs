using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Cinema
{
    public partial class frm_CinemaFullDetails : Form
    {
        private readonly APIService _service = new APIService("cinema");
        private readonly APIService _cityService = new APIService("city");
        private readonly int? _cinemaId = null;

        public frm_CinemaFullDetails(int? id = null)
        {
            InitializeComponent();
            _cinemaId = id;
        }

        private async void frm_CinemaFullDetails_Load(object sender, EventArgs e)
        {
            if (_cinemaId.HasValue)
            {
                var cinema = await _service.GetById<Model.Cinema>(_cinemaId);

                txtNazivKina.Text = cinema.CinemaName;
                txtAdresa.Text = cinema.Address;
                txtTelefon.Text = cinema.TelephoneNumber;
            }
            await LoadCities();
        }
        private async Task LoadCities()
        {
            var result = await _cityService.Get<List<Model.City>>(null);
            result.Insert(0, new Model.City());
            cb_Gradovi.DataSource = result;
            cb_Gradovi.DisplayMember = "CityName";
            cb_Gradovi.ValueMember = "CityId";

        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                var request = new CinemaUpsertRequest()
                {
                    CinemaName = txtNazivKina.Text,
                    Address = txtAdresa.Text,
                    TelephoneNumber = txtTelefon.Text,
                    CityId = int.Parse(cb_Gradovi.SelectedValue.ToString())
                };
                if (_cinemaId.HasValue)
                {
                    await _service.Update<Model.Cinema>(_cinemaId, request);
                }

                MessageBox.Show("Izmjena uspjesno odradjena!");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Kino", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
