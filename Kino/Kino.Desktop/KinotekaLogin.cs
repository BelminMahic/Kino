using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kino.Desktop
{
    public partial class KinotekaLogin : Form
    {

        private readonly APIService _service = new APIService("user");

        public KinotekaLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.UserName = txtUsername.Text;
            APIService.Password = txtPass.Text;
            try
            {
                var result = await _service.Get<List<Model.User>>(null);
                KinotekaMainWindow frm = new KinotekaMainWindow();
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Pogresan username ili password!");
            }
        }

       
    }
}
