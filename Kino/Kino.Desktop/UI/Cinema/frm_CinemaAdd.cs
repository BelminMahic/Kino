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
    public partial class frm_CinemaAdd : Form
    {
        private readonly APIService _service = new APIService("cinema");
        private readonly APIService _cityService = new APIService("city");

        public frm_CinemaAdd()
        {
            InitializeComponent();
        }

        private async void frm_CinemaAdd_Load(object sender, EventArgs e)
        {
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren()) { 
            var request = new CinemaUpsertRequest()
            {
                CinemaName = txtNazivKina.Text,
                Address = txtAdresa.Text,
                TelephoneNumber = txtTelefon.Text,
                CityId = int.Parse(cb_Gradovi.SelectedValue.ToString())
            };
            await _service.Insert<Model.Cinema>(request);
            MessageBox.Show("Dodavanje uspjesno odradjeno!");
            }
        }

        private void txtNazivKina_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivKina.Text))
            {
                errorProvider.SetError(txtNazivKina, "Naziv kina je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtNazivKina, null);

            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                errorProvider.SetError(txtAdresa, "Adresa je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAdresa, null);

            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                errorProvider.SetError(txtTelefon, "Broj telefona je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTelefon, null);

            }
        }
    }
}
