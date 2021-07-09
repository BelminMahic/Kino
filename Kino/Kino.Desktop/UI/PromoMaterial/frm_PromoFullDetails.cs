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
    public partial class frm_PromoFullDetails : Form
    {
        private readonly APIService _promoService = new APIService("promomaterial");

        private int? _promoId = null;
        public frm_PromoFullDetails(int? id=null)
        {
            InitializeComponent();
            _promoId = id;
        }

        private async void frm_PromoFullDetails_Load(object sender, EventArgs e)
        {
            if (_promoId.HasValue)
            {
                var promo = await _promoService.GetById<Model.PromoMaterial>(_promoId);

                txtPromoName.Text = promo.PromoMaterialName;
                txtPromoQuantity.Text = promo.Quantity.ToString();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var request = new PromoMaterialUpsertRequest
            {
                PromoMaterialName = txtPromoName.Text,
                Quantity = int.Parse(txtPromoQuantity.Text)
            };
            if (_promoId.HasValue)
            {
                await _promoService.Update<Model.PromoMaterial>(_promoId, request);
            }

            MessageBox.Show("Izmjena uspjesno uradjena!");
        }
    }
}
