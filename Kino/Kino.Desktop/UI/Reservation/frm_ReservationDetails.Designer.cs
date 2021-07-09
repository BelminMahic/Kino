﻿
namespace Kino.Desktop.UI.Reservation
{
    partial class frm_ReservationDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelRezervacije = new System.Windows.Forms.Panel();
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
            this.cb_Kina = new System.Windows.Forms.ComboBox();
            this.cb_Film = new System.Windows.Forms.ComboBox();
            this.cb_Dvorana = new System.Windows.Forms.ComboBox();
            this.cb_DatumPrikazivanja = new System.Windows.Forms.ComboBox();
            this.cb_VrijemePrikazivanja = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblKino = new System.Windows.Forms.Label();
            this.lblFilm = new System.Windows.Forms.Label();
            this.cb_Auditorium = new System.Windows.Forms.Label();
            this.lbl_DatumP = new System.Windows.Forms.Label();
            this.lbl_VrijemeP = new System.Windows.Forms.Label();
            this.gb_Rezervacije = new System.Windows.Forms.GroupBox();
            this.dgv_Rezervacije = new System.Windows.Forms.DataGridView();
            this.btnSeatReservation = new System.Windows.Forms.Button();
            this.panelRezervacije.SuspendLayout();
            this.gb_Rezervacije.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rezervacije)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRezervacije
            // 
            this.panelRezervacije.BackColor = System.Drawing.Color.White;
            this.panelRezervacije.Controls.Add(this.btnSeatReservation);
            this.panelRezervacije.Controls.Add(this.btnKina);
            this.panelRezervacije.Controls.Add(this.btnProfile);
            this.panelRezervacije.Controls.Add(this.btnReports);
            this.panelRezervacije.Controls.Add(this.btnUsers);
            this.panelRezervacije.Controls.Add(this.btnPromo);
            this.panelRezervacije.Controls.Add(this.btnDrzave);
            this.panelRezervacije.Controls.Add(this.btnGradovi);
            this.panelRezervacije.Controls.Add(this.btnZanrovi);
            this.panelRezervacije.Controls.Add(this.btnRezervacije);
            this.panelRezervacije.Controls.Add(this.btnSjedista);
            this.panelRezervacije.Controls.Add(this.btnDvorane);
            this.panelRezervacije.Controls.Add(this.btnFilmovi);
            this.panelRezervacije.Location = new System.Drawing.Point(0, -1);
            this.panelRezervacije.Name = "panelRezervacije";
            this.panelRezervacije.Size = new System.Drawing.Size(279, 625);
            this.panelRezervacije.TabIndex = 1;
            // 
            // btnKina
            // 
            this.btnKina.Location = new System.Drawing.Point(0, 523);
            this.btnKina.Name = "btnKina";
            this.btnKina.Size = new System.Drawing.Size(276, 23);
            this.btnKina.TabIndex = 11;
            this.btnKina.Text = "Kina";
            this.btnKina.UseVisualStyleBackColor = true;
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(0, 484);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(276, 23);
            this.btnProfile.TabIndex = 10;
            this.btnProfile.Text = "Profil";
            this.btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(0, 441);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(276, 23);
            this.btnReports.TabIndex = 9;
            this.btnReports.Text = "Izvjestaji";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(0, 402);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(276, 23);
            this.btnUsers.TabIndex = 8;
            this.btnUsers.Text = "Korisnici";
            this.btnUsers.UseVisualStyleBackColor = true;
            // 
            // btnPromo
            // 
            this.btnPromo.Location = new System.Drawing.Point(0, 363);
            this.btnPromo.Name = "btnPromo";
            this.btnPromo.Size = new System.Drawing.Size(276, 23);
            this.btnPromo.TabIndex = 7;
            this.btnPromo.Text = "Promidzbeni materijali";
            this.btnPromo.UseVisualStyleBackColor = true;
            // 
            // btnDrzave
            // 
            this.btnDrzave.Location = new System.Drawing.Point(0, 321);
            this.btnDrzave.Name = "btnDrzave";
            this.btnDrzave.Size = new System.Drawing.Size(276, 23);
            this.btnDrzave.TabIndex = 6;
            this.btnDrzave.Text = "Drzave";
            this.btnDrzave.UseVisualStyleBackColor = true;
            // 
            // btnGradovi
            // 
            this.btnGradovi.Location = new System.Drawing.Point(0, 279);
            this.btnGradovi.Name = "btnGradovi";
            this.btnGradovi.Size = new System.Drawing.Size(276, 23);
            this.btnGradovi.TabIndex = 5;
            this.btnGradovi.Text = "Gradovi";
            this.btnGradovi.UseVisualStyleBackColor = true;
            // 
            // btnZanrovi
            // 
            this.btnZanrovi.Location = new System.Drawing.Point(0, 235);
            this.btnZanrovi.Name = "btnZanrovi";
            this.btnZanrovi.Size = new System.Drawing.Size(276, 23);
            this.btnZanrovi.TabIndex = 4;
            this.btnZanrovi.Text = "Zanrovi";
            this.btnZanrovi.UseVisualStyleBackColor = true;
            // 
            // btnRezervacije
            // 
            this.btnRezervacije.Location = new System.Drawing.Point(0, 193);
            this.btnRezervacije.Name = "btnRezervacije";
            this.btnRezervacije.Size = new System.Drawing.Size(276, 23);
            this.btnRezervacije.TabIndex = 3;
            this.btnRezervacije.Text = "Rezervacije";
            this.btnRezervacije.UseVisualStyleBackColor = true;
            // 
            // btnSjedista
            // 
            this.btnSjedista.Location = new System.Drawing.Point(0, 153);
            this.btnSjedista.Name = "btnSjedista";
            this.btnSjedista.Size = new System.Drawing.Size(276, 23);
            this.btnSjedista.TabIndex = 2;
            this.btnSjedista.Text = "Sjedista";
            this.btnSjedista.UseVisualStyleBackColor = true;
            // 
            // btnDvorane
            // 
            this.btnDvorane.Location = new System.Drawing.Point(0, 97);
            this.btnDvorane.Name = "btnDvorane";
            this.btnDvorane.Size = new System.Drawing.Size(276, 23);
            this.btnDvorane.TabIndex = 1;
            this.btnDvorane.Text = "Dvorane";
            this.btnDvorane.UseVisualStyleBackColor = true;
            // 
            // btnFilmovi
            // 
            this.btnFilmovi.Location = new System.Drawing.Point(0, 68);
            this.btnFilmovi.Name = "btnFilmovi";
            this.btnFilmovi.Size = new System.Drawing.Size(276, 23);
            this.btnFilmovi.TabIndex = 0;
            this.btnFilmovi.Text = "Filmovi";
            this.btnFilmovi.UseVisualStyleBackColor = true;
            // 
            // cb_Kina
            // 
            this.cb_Kina.FormattingEnabled = true;
            this.cb_Kina.Location = new System.Drawing.Point(294, 25);
            this.cb_Kina.Name = "cb_Kina";
            this.cb_Kina.Size = new System.Drawing.Size(121, 23);
            this.cb_Kina.TabIndex = 2;
            // 
            // cb_Film
            // 
            this.cb_Film.FormattingEnabled = true;
            this.cb_Film.Location = new System.Drawing.Point(443, 25);
            this.cb_Film.Name = "cb_Film";
            this.cb_Film.Size = new System.Drawing.Size(121, 23);
            this.cb_Film.TabIndex = 3;
            // 
            // cb_Dvorana
            // 
            this.cb_Dvorana.FormattingEnabled = true;
            this.cb_Dvorana.Location = new System.Drawing.Point(594, 25);
            this.cb_Dvorana.Name = "cb_Dvorana";
            this.cb_Dvorana.Size = new System.Drawing.Size(121, 23);
            this.cb_Dvorana.TabIndex = 4;
            // 
            // cb_DatumPrikazivanja
            // 
            this.cb_DatumPrikazivanja.FormattingEnabled = true;
            this.cb_DatumPrikazivanja.Location = new System.Drawing.Point(759, 25);
            this.cb_DatumPrikazivanja.Name = "cb_DatumPrikazivanja";
            this.cb_DatumPrikazivanja.Size = new System.Drawing.Size(121, 23);
            this.cb_DatumPrikazivanja.TabIndex = 5;
            // 
            // cb_VrijemePrikazivanja
            // 
            this.cb_VrijemePrikazivanja.FormattingEnabled = true;
            this.cb_VrijemePrikazivanja.Location = new System.Drawing.Point(907, 25);
            this.cb_VrijemePrikazivanja.Name = "cb_VrijemePrikazivanja";
            this.cb_VrijemePrikazivanja.Size = new System.Drawing.Size(121, 23);
            this.cb_VrijemePrikazivanja.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1052, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 39);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "🔍";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblKino
            // 
            this.lblKino.AutoSize = true;
            this.lblKino.Location = new System.Drawing.Point(294, 4);
            this.lblKino.Name = "lblKino";
            this.lblKino.Size = new System.Drawing.Size(31, 15);
            this.lblKino.TabIndex = 8;
            this.lblKino.Text = "Kino";
            // 
            // lblFilm
            // 
            this.lblFilm.AutoSize = true;
            this.lblFilm.Location = new System.Drawing.Point(443, 7);
            this.lblFilm.Name = "lblFilm";
            this.lblFilm.Size = new System.Drawing.Size(30, 15);
            this.lblFilm.TabIndex = 9;
            this.lblFilm.Text = "Film";
            // 
            // cb_Auditorium
            // 
            this.cb_Auditorium.AutoSize = true;
            this.cb_Auditorium.Location = new System.Drawing.Point(594, 4);
            this.cb_Auditorium.Name = "cb_Auditorium";
            this.cb_Auditorium.Size = new System.Drawing.Size(51, 15);
            this.cb_Auditorium.TabIndex = 10;
            this.cb_Auditorium.Text = "Dvorana";
            // 
            // lbl_DatumP
            // 
            this.lbl_DatumP.AutoSize = true;
            this.lbl_DatumP.Location = new System.Drawing.Point(759, 9);
            this.lbl_DatumP.Name = "lbl_DatumP";
            this.lbl_DatumP.Size = new System.Drawing.Size(108, 15);
            this.lbl_DatumP.TabIndex = 11;
            this.lbl_DatumP.Text = "Datum prikazivanja";
            // 
            // lbl_VrijemeP
            // 
            this.lbl_VrijemeP.AutoSize = true;
            this.lbl_VrijemeP.Location = new System.Drawing.Point(907, 7);
            this.lbl_VrijemeP.Name = "lbl_VrijemeP";
            this.lbl_VrijemeP.Size = new System.Drawing.Size(112, 15);
            this.lbl_VrijemeP.TabIndex = 12;
            this.lbl_VrijemeP.Text = "Vrijeme prikazivanja";
            // 
            // gb_Rezervacije
            // 
            this.gb_Rezervacije.Controls.Add(this.dgv_Rezervacije);
            this.gb_Rezervacije.Location = new System.Drawing.Point(283, 112);
            this.gb_Rezervacije.Name = "gb_Rezervacije";
            this.gb_Rezervacije.Size = new System.Drawing.Size(862, 498);
            this.gb_Rezervacije.TabIndex = 13;
            this.gb_Rezervacije.TabStop = false;
            this.gb_Rezervacije.Text = "Lista rezervacija";
            // 
            // dgv_Rezervacije
            // 
            this.dgv_Rezervacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Rezervacije.Location = new System.Drawing.Point(11, 22);
            this.dgv_Rezervacije.Name = "dgv_Rezervacije";
            this.dgv_Rezervacije.RowTemplate.Height = 25;
            this.dgv_Rezervacije.Size = new System.Drawing.Size(845, 461);
            this.dgv_Rezervacije.TabIndex = 0;
            // 
            // btnSeatReservation
            // 
            this.btnSeatReservation.Location = new System.Drawing.Point(0, 126);
            this.btnSeatReservation.Name = "btnSeatReservation";
            this.btnSeatReservation.Size = new System.Drawing.Size(276, 23);
            this.btnSeatReservation.TabIndex = 12;
            this.btnSeatReservation.Text = "Rezervacija sjedista";
            this.btnSeatReservation.UseVisualStyleBackColor = true;
            // 
            // frm_ReservationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1157, 622);
            this.Controls.Add(this.gb_Rezervacije);
            this.Controls.Add(this.lbl_VrijemeP);
            this.Controls.Add(this.lbl_DatumP);
            this.Controls.Add(this.cb_Auditorium);
            this.Controls.Add(this.lblFilm);
            this.Controls.Add(this.lblKino);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cb_VrijemePrikazivanja);
            this.Controls.Add(this.cb_DatumPrikazivanja);
            this.Controls.Add(this.cb_Dvorana);
            this.Controls.Add(this.cb_Film);
            this.Controls.Add(this.cb_Kina);
            this.Controls.Add(this.panelRezervacije);
            this.Name = "frm_ReservationDetails";
            this.Text = "Kinoteka : Rezervacije";
            this.Load += new System.EventHandler(this.frm_ReservationDetails_Load);
            this.panelRezervacije.ResumeLayout(false);
            this.gb_Rezervacije.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rezervacije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelRezervacije;
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
        private System.Windows.Forms.Button btnFilmovi;
        private System.Windows.Forms.ComboBox cb_Kina;
        private System.Windows.Forms.ComboBox cb_Film;
        private System.Windows.Forms.ComboBox cb_Dvorana;
        private System.Windows.Forms.ComboBox cb_DatumPrikazivanja;
        private System.Windows.Forms.ComboBox cb_VrijemePrikazivanja;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblKino;
        private System.Windows.Forms.Label lblFilm;
        private System.Windows.Forms.Label cb_Auditorium;
        private System.Windows.Forms.Label lbl_DatumP;
        private System.Windows.Forms.Label lbl_VrijemeP;
        private System.Windows.Forms.GroupBox gb_Rezervacije;
        private System.Windows.Forms.DataGridView dgv_Rezervacije;
        private System.Windows.Forms.Button btnSeatReservation;
    }
}