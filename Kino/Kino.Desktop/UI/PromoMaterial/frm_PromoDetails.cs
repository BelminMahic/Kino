using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kino.Desktop.UI.PromoMaterial
{
    public partial class frm_PromoDetails : Form
    {


        private readonly APIService _promoService = new APIService("promomaterial");
        public frm_PromoDetails()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frm_PromoAdd frm = new frm_PromoAdd();
            frm.Show();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new PromoMaterialSearchRequest()
            {
                PromoMaterialName = txtSearch.Text
            };
            var result = await _promoService.Get<List<Model.PromoMaterial>>(search);

            dgvPromoMaterijali.DataSource = result;
        }

        private void dgvPromoMaterijali_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvPromoMaterijali.SelectedRows[0].Cells[0].Value;
            frm_PromoFullDetails frm = new frm_PromoFullDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
