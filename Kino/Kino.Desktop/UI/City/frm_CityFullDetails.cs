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
    public partial class frm_CityFullDetails : Form
    {
        private readonly APIService _cityService = new APIService("city");
        private readonly APIService _countryService = new APIService("country");

        private int? _cityId = null;
        public frm_CityFullDetails(int? id=null)
        {
            InitializeComponent();
            _cityId = id;
        }

        private async void frm_CityFullDetails_Load(object sender, EventArgs e)
        {
            if (_cityId.HasValue)
            {
                var city = await _cityService.GetById<Model.City>(_cityId);

                txtNazivGrada.Text = city.CityName;

            }

            await LoadCountries();
        }

        private async Task LoadCountries()
        {
            var result = await _countryService.Get<List<Model.Country>>(null);
            result.Insert(0, new Model.Country());
            cb_Drzave.DataSource = result;
            cb_Drzave.DisplayMember = "CountryName";
            cb_Drzave.ValueMember = "CountryId";

        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                var request = new CityUpsertRequest()
                {
                    CityName = txtNazivGrada.Text,
                    CountryId = int.Parse(cb_Drzave.SelectedValue.ToString())
                };
                if (_cityId.HasValue)
                {
                    await _cityService.Update<Model.City>(_cityId, request);
                }

                MessageBox.Show("Izmjena uspjesno odradjena!");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Grad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
