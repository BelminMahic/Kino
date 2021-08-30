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
    public partial class frm_CountryFullDetails : Form
    {
        private readonly APIService _service = new APIService("country");
        private int? _id = null;
        public frm_CountryFullDetails(int? countryId = null)
        {
            InitializeComponent();
            _id = countryId;
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                var request = new CountryUpsertRequest()
                {
                    CountryName = txtNazivDrzave.Text
                };
                if (_id.HasValue)
                {
                    await _service.Update<Model.Country>(_id, request);
                }

                MessageBox.Show("Izmjena uspjesno odradjena!");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Drzava", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void frm_CountryFullDetails_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var country = await _service.GetById<Model.Country>(_id);

                txtNazivDrzave.Text = country.CountryName;
            }
        }
    }
}
