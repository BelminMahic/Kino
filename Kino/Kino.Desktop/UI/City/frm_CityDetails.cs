using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kino.Desktop.UI.City
{
    public partial class frm_CityDetails : Form
    {

        private readonly APIService _cityService = new APIService("city");
        public frm_CityDetails()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new CitySearchRequest
            {
                CityName = txtSearch.Text
            };

            var result = await _cityService.Get<List<Model.City>>(search);

            dgv_Gradovi.DataSource = result;
        }

        private void dgv_Gradovi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgv_Gradovi.SelectedRows[0].Cells[0].Value;
            frm_CityFullDetails frm = new frm_CityFullDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
