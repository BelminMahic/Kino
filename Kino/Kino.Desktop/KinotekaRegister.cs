using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kino.Desktop
{
    public partial class KinotekaRegister : Form
    {

        private readonly APIService _userService = new APIService("user");
        private readonly APIService _genderService = new APIService("gender");

        private int? _id = null;

        public KinotekaRegister()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            
            if (this.ValidateChildren())
            {
                var request = new UserUpsertRequest
                {
                    Email = txtEmail.Text,
                    Name = txtIme.Text,
                    UserName = txtUsername.Text,
                    Password = txtSifra.Text,
                    PasswordConfirmation = txtPotvrda.Text,
                    LastName = txtPrezime.Text,
                    Phone = txtTelefon.Text,
                    GenderId = int.Parse(cb_Spolovi.SelectedValue.ToString())
                };

                Model.User entity = null;
                if (!_id.HasValue)
                {
                    entity = await _userService.Insert<Model.User>(request);
                }
                else
                {
                    entity = await _userService.Update<Model.User>(_id.Value, request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                }
            }
        }


        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, "Ime je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtIme, null);

            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, "Prezime je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrezime, null);

            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, "Korisnicko ime je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUsername, null);

            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Email je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);

            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                errorProvider.SetError(txtTelefon, "Telefon je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTelefon, null);

            }
        }

        private void txtSifra_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSifra.Text))
            {
                errorProvider.SetError(txtSifra, "Sifra je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtSifra, null);

            }
        }

        private void txtPotvrda_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPotvrda.Text))
            {
                errorProvider.SetError(txtPotvrda, "Potvrda sifre je obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPotvrda, null);

            }
        }

       
    }
}
