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

       
    }
}
