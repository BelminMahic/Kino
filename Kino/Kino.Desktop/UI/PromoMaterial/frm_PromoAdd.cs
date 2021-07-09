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
    public partial class frm_PromoAdd : Form
    {
        private readonly APIService _promoService = new APIService("promomaterial");
        public frm_PromoAdd()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = new PromoMaterialUpsertRequest
            {
                PromoMaterialName = txtPromoName.Text,
                Quantity = int.Parse(txtPromoQuantity.Text)
            };

            await _promoService.Insert<Model.PromoMaterial>(request);
            MessageBox.Show("Promo materijal je uspjesno dodan!");
        }
    }
}
