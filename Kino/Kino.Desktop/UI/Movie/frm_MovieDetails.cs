using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Movie
{
    public partial class frm_MovieDetails : Form
    {
        private readonly APIService _movieService = new APIService("movie");

        public frm_MovieDetails()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frm_MovieAdd frm = new frm_MovieAdd();
            frm.Show();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var request = new MovieSearchRequest
            {
                MovieName = txtSearch.Text
            };

            var result = await _movieService.Get<List<Model.Movie>>(request);
            dgv_Filmovi.DataSource = result;
        }

        private void dgv_Filmovi_DoubleClick(object sender, EventArgs e)
        {
            var id = dgv_Filmovi.SelectedRows[0].Cells[0].Value;
            frm_MovieFullDetails frm = new frm_MovieFullDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
