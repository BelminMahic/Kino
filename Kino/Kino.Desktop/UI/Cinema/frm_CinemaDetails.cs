using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Cinema
{
    public partial class frm_CinemaDetails : Form
    {

        private readonly APIService _apiService = new APIService("cinema");

        public frm_CinemaDetails()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frm_CinemaAdd frm = new frm_CinemaAdd();
            frm.Show();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new CinemaSearchRequest
            {
                CinemaName = txtSearch.Text
            };

            var result = await _apiService.Get<List<Model.Cinema>>(search);

            dgv_Kina.DataSource = result;
        }

        private void dgv_Kina_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgv_Kina.SelectedRows[0].Cells[0].Value;
            frm_CinemaFullDetails frm = new frm_CinemaFullDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
