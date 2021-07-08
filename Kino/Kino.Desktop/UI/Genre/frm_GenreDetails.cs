using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Genre
{
    public partial class frm_GenreDetails : Form
    {
        private readonly APIService _genreService = new APIService("genre");

        public frm_GenreDetails()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frm_GenreAdd frm = new frm_GenreAdd();
            frm.Show();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new GenreSearchRequest()
            {
                GenreName = txtSearch.Text
            };
            var result = await _genreService.Get<List<Model.Genre>>(search);

            dgvZanrovi.DataSource = result;
        }
    }
}
