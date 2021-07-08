using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Auditorium
{
    public partial class frm_AuditoriumDetails : Form
    {
        private readonly APIService _apiService = new APIService("auditorium");

        public frm_AuditoriumDetails()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frm_AuditoriumAdd frm = new frm_AuditoriumAdd();
            frm.Show();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new AuditoriumSearchRequest
            {
                AuditoriumName = txtSearch.Text
            };

            var result = await _apiService.Get<List<Model.Auditorium>>(search);

            dgv_Auditorium.DataSource = result;
        }

        private void dgv_Auditorium_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgv_Auditorium.SelectedRows[0].Cells[0].Value;
            frm_AuditoriumFullDetails frm = new frm_AuditoriumFullDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
