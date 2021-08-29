using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino.Desktop.UI.City
{
    public partial class frm_CityAdd : Form
    {

        private readonly APIService _cityService = new APIService("city");
        private readonly APIService _countryService = new APIService("country");


        public frm_CityAdd()
        {
            InitializeComponent();
        }
        private async void frm_CityAdd_Load(object sender, EventArgs e)
        {
            await LoadDrzave();

        }
        private async Task LoadDrzave()
        {
            var result = await _countryService.Get<List<Model.Country>>(null);
            result.Insert(0, new Model.Country());
            cb_Drzave.DisplayMember = "CountryName";
            cb_Drzave.ValueMember = "CountryId";
            cb_Drzave.DataSource = result;
        }

        private void txtNazivGrada_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivGrada.Text))
            {
                errorProvider.SetError(txtNazivGrada, "Naziv grada je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtNazivGrada, null);

            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.ValidateChildren())
                {
                    var request = new CityUpsertRequest()
                    {
                        CityName = txtNazivGrada.Text,
                        CountryId = int.Parse(cb_Drzave.SelectedValue.ToString())
                    };

                    await _cityService.Insert<Model.City>(request);
                    MessageBox.Show("Dodavanje uspjesno odradjeno!");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Grad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
