
namespace Kino.Desktop
{
    partial class KinotekaMainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMainWindow = new System.Windows.Forms.Panel();
            this.btnSeatReservation = new System.Windows.Forms.Button();
            this.btnKina = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnPromo = new System.Windows.Forms.Button();
            this.btnDrzave = new System.Windows.Forms.Button();
            this.btnGradovi = new System.Windows.Forms.Button();
            this.btnZanrovi = new System.Windows.Forms.Button();
            this.btnRezervacije = new System.Windows.Forms.Button();
            this.btnSjedista = new System.Windows.Forms.Button();
            this.btnDvorane = new System.Windows.Forms.Button();
            this.btnFilmovi = new System.Windows.Forms.Button();
            this.panelMainWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainWindow
            // 
            this.panelMainWindow.BackColor = System.Drawing.Color.White;
            this.panelMainWindow.Controls.Add(this.btnSeatReservation);
            this.panelMainWindow.Controls.Add(this.btnKina);
            this.panelMainWindow.Controls.Add(this.btnProfile);
            this.panelMainWindow.Controls.Add(this.btnReports);
            this.panelMainWindow.Controls.Add(this.btnUsers);
            this.panelMainWindow.Controls.Add(this.btnPromo);
            this.panelMainWindow.Controls.Add(this.btnDrzave);
            this.panelMainWindow.Controls.Add(this.btnGradovi);
            this.panelMainWindow.Controls.Add(this.btnZanrovi);
            this.panelMainWindow.Controls.Add(this.btnRezervacije);
            this.panelMainWindow.Controls.Add(this.btnSjedista);
            this.panelMainWindow.Controls.Add(this.btnDvorane);
            this.panelMainWindow.Controls.Add(this.btnFilmovi);
            this.panelMainWindow.Location = new System.Drawing.Point(1, -1);
            this.panelMainWindow.Name = "panelMainWindow";
            this.panelMainWindow.Size = new System.Drawing.Size(276, 625);
            this.panelMainWindow.TabIndex = 0;
            // 
            // btnSeatReservation
            // 
            this.btnSeatReservation.Location = new System.Drawing.Point(0, 124);
            this.btnSeatReservation.Name = "btnSeatReservation";
            this.btnSeatReservation.Size = new System.Drawing.Size(276, 23);
            this.btnSeatReservation.TabIndex = 12;
            this.btnSeatReservation.Text = "Rezervacija sjedista";
            this.btnSeatReservation.UseVisualStyleBackColor = true;
            this.btnSeatReservation.Click += new System.EventHandler(this.btnSeatReservation_Click);
            // 
            // btnKina
            // 
            this.btnKina.Location = new System.Drawing.Point(0, 523);
            this.btnKina.Name = "btnKina";
            this.btnKina.Size = new System.Drawing.Size(276, 23);
            this.btnKina.TabIndex = 11;
            this.btnKina.Text = "Kina";
            this.btnKina.UseVisualStyleBackColor = true;
            this.btnKina.Click += new System.EventHandler(this.btnKina_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(0, 484);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(276, 23);
            this.btnProfile.TabIndex = 10;
            this.btnProfile.Text = "Profil";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(0, 441);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(276, 23);
            this.btnReports.TabIndex = 9;
            this.btnReports.Text = "Izvjestaji";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(0, 402);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(276, 23);
            this.btnUsers.TabIndex = 8;
            this.btnUsers.Text = "Korisnici";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnPromo
            // 
            this.btnPromo.Location = new System.Drawing.Point(0, 363);
            this.btnPromo.Name = "btnPromo";
            this.btnPromo.Size = new System.Drawing.Size(276, 23);
            this.btnPromo.TabIndex = 7;
            this.btnPromo.Text = "Promidzbeni materijali";
            this.btnPromo.UseVisualStyleBackColor = true;
            this.btnPromo.Click += new System.EventHandler(this.btnPromo_Click);
            // 
            // btnDrzave
            // 
            this.btnDrzave.Location = new System.Drawing.Point(0, 321);
            this.btnDrzave.Name = "btnDrzave";
            this.btnDrzave.Size = new System.Drawing.Size(276, 23);
            this.btnDrzave.TabIndex = 6;
            this.btnDrzave.Text = "Drzave";
            this.btnDrzave.UseVisualStyleBackColor = true;
            this.btnDrzave.Click += new System.EventHandler(this.btnDrzave_Click);
            // 
            // btnGradovi
            // 
            this.btnGradovi.Location = new System.Drawing.Point(0, 279);
            this.btnGradovi.Name = "btnGradovi";
            this.btnGradovi.Size = new System.Drawing.Size(276, 23);
            this.btnGradovi.TabIndex = 5;
            this.btnGradovi.Text = "Gradovi";
            this.btnGradovi.UseVisualStyleBackColor = true;
            this.btnGradovi.Click += new System.EventHandler(this.btnGradovi_Click);
            // 
            // btnZanrovi
            // 
            this.btnZanrovi.Location = new System.Drawing.Point(0, 235);
            this.btnZanrovi.Name = "btnZanrovi";
            this.btnZanrovi.Size = new System.Drawing.Size(276, 23);
            this.btnZanrovi.TabIndex = 4;
            this.btnZanrovi.Text = "Zanrovi";
            this.btnZanrovi.UseVisualStyleBackColor = true;
            this.btnZanrovi.Click += new System.EventHandler(this.btnZanrovi_Click);
            // 
            // btnRezervacije
            // 
            this.btnRezervacije.Location = new System.Drawing.Point(0, 193);
            this.btnRezervacije.Name = "btnRezervacije";
            this.btnRezervacije.Size = new System.Drawing.Size(276, 23);
            this.btnRezervacije.TabIndex = 3;
            this.btnRezervacije.Text = "Rezervacije";
            this.btnRezervacije.UseVisualStyleBackColor = true;
            this.btnRezervacije.Click += new System.EventHandler(this.btnRezervacije_Click);
            // 
            // btnSjedista
            // 
            this.btnSjedista.Location = new System.Drawing.Point(0, 153);
            this.btnSjedista.Name = "btnSjedista";
            this.btnSjedista.Size = new System.Drawing.Size(276, 23);
            this.btnSjedista.TabIndex = 2;
            this.btnSjedista.Text = "Sjedista";
            this.btnSjedista.UseVisualStyleBackColor = true;
            this.btnSjedista.Click += new System.EventHandler(this.btnSjedista_Click);
            // 
            // btnDvorane
            // 
            this.btnDvorane.Location = new System.Drawing.Point(0, 95);
            this.btnDvorane.Name = "btnDvorane";
            this.btnDvorane.Size = new System.Drawing.Size(276, 23);
            this.btnDvorane.TabIndex = 1;
            this.btnDvorane.Text = "Dvorane";
            this.btnDvorane.UseVisualStyleBackColor = true;
            this.btnDvorane.Click += new System.EventHandler(this.btnDvorane_Click);
            // 
            // btnFilmovi
            // 
            this.btnFilmovi.Location = new System.Drawing.Point(-3, 56);
            this.btnFilmovi.Name = "btnFilmovi";
            this.btnFilmovi.Size = new System.Drawing.Size(276, 23);
            this.btnFilmovi.TabIndex = 0;
            this.btnFilmovi.Text = "Filmovi";
            this.btnFilmovi.UseVisualStyleBackColor = true;
            this.btnFilmovi.Click += new System.EventHandler(this.btnFilmovi_Click);
            // 
            // KinotekaMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kino.Desktop.Properties.Resources.Kinoteka1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1157, 622);
            this.Controls.Add(this.panelMainWindow);
            this.Name = "KinotekaMainWindow";
            this.Text = "Kinoteka";
            this.panelMainWindow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainWindow;
        private System.Windows.Forms.Button btnFilmovi;
        private System.Windows.Forms.Button btnKina;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnPromo;
        private System.Windows.Forms.Button btnDrzave;
        private System.Windows.Forms.Button btnGradovi;
        private System.Windows.Forms.Button btnZanrovi;
        private System.Windows.Forms.Button btnRezervacije;
        private System.Windows.Forms.Button btnSjedista;
        private System.Windows.Forms.Button btnDvorane;
        private System.Windows.Forms.Button btnSeatReservation;
    }
}

