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
    public partial class frm_GenreAdd : Form
    {
        private readonly APIService _genreService = new APIService("genre");

        public frm_GenreAdd()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren()) { 
            var request = new GenreUpsertRequest
            {
                GenreName = txtNazivZanra.Text
            };

            await _genreService.Insert<Model.Genre>(request);
            MessageBox.Show("Zanr je uspjesno dodan!");
            }
        }

        private void txtNazivZanra_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivZanra.Text))
            {
                errorProvider.SetError(txtNazivZanra, "Naziv zanra je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtNazivZanra, null);

            }
        }
    }
}
