using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Country
{
    public partial class frm_CountryDetails : Form
    {
        private readonly APIService _aPIService = new APIService("country");

        public frm_CountryDetails()
        {
            InitializeComponent();
        }
              

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new CountrySearchRequest()
            {
                CountryName = txtSearch.Text
            };
            var result = await _aPIService.Get<List<Model.Country>>(search);

            dgv_Drzave.DataSource = result;
        }

        private void dgv_Drzave_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgv_Drzave.SelectedRows[0].Cells[0].Value;
            frm_CountryFullDetails frm = new frm_CountryFullDetails(int.Parse(id.ToString()));
            frm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frm_CountryAdd frm = new frm_CountryAdd();
            frm.Show();
        }
    }
}
