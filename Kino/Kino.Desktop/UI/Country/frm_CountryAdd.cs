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
    public partial class frm_CountryAdd : Form
    {
        private readonly APIService _aPIService = new APIService("country");

        public frm_CountryAdd()
        {
            InitializeComponent();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = new CountryUpsertRequest()
            {
                CountryName = txtNazivDrzave.Text
            };

            await _aPIService.Insert<Model.Country>(request);
            MessageBox.Show("Dodavanje uspjesno odradjeno!");

        }
    }
}
