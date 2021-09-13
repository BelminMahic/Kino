
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
            this.btnSeatReservation = new System.Windows.Forms.Button();
            this.btnKina = new System.Windows.Forms.Button();
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
            this.cb_Dvorana = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cb_Auditorium = new System.Windows.Forms.Label();
            this.gb_Rezervacije = new System.Windows.Forms.GroupBox();
            this.dgv_Rezervacije = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Prikazivanja = new System.Windows.Forms.ComboBox();
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
            // btnSeatReservation
            // 
            this.btnSeatReservation.Location = new System.Drawing.Point(0, 126);
            this.btnSeatReservation.Name = "btnSeatReservation";
            this.btnSeatReservation.Size = new System.Drawing.Size(276, 23);
            this.btnSeatReservation.TabIndex = 12;
            this.btnSeatReservation.Text = "Rezervacija sjedista";
            this.btnSeatReservation.UseVisualStyleBackColor = true;
            this.btnSeatReservation.Click += new System.EventHandler(this.btnSeatReservation_Click);
            // 
            // btnKina
            // 
            this.btnKina.Location = new System.Drawing.Point(1, 487);
            this.btnKina.Name = "btnKina";
            this.btnKina.Size = new System.Drawing.Size(276, 23);
            this.btnKina.TabIndex = 11;
            this.btnKina.Text = "Kina";
            this.btnKina.UseVisualStyleBackColor = true;
            this.btnKina.Click += new System.EventHandler(this.btnKina_Click);
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
            this.btnDvorane.Location = new System.Drawing.Point(0, 97);
            this.btnDvorane.Name = "btnDvorane";
            this.btnDvorane.Size = new System.Drawing.Size(276, 23);
            this.btnDvorane.TabIndex = 1;
            this.btnDvorane.Text = "Dvorane";
            this.btnDvorane.UseVisualStyleBackColor = true;
            this.btnDvorane.Click += new System.EventHandler(this.btnDvorane_Click);
            // 
            // btnFilmovi
            // 
            this.btnFilmovi.Location = new System.Drawing.Point(0, 68);
            this.btnFilmovi.Name = "btnFilmovi";
            this.btnFilmovi.Size = new System.Drawing.Size(276, 23);
            this.btnFilmovi.TabIndex = 0;
            this.btnFilmovi.Text = "Filmovi";
            this.btnFilmovi.UseVisualStyleBackColor = true;
            this.btnFilmovi.Click += new System.EventHandler(this.btnFilmovi_Click);
            // 
            // cb_Dvorana
            // 
            this.cb_Dvorana.FormattingEnabled = true;
            this.cb_Dvorana.Location = new System.Drawing.Point(294, 32);
            this.cb_Dvorana.Name = "cb_Dvorana";
            this.cb_Dvorana.Size = new System.Drawing.Size(121, 23);
            this.cb_Dvorana.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(981, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 39);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "🔍";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cb_Auditorium
            // 
            this.cb_Auditorium.AutoSize = true;
            this.cb_Auditorium.Location = new System.Drawing.Point(294, 7);
            this.cb_Auditorium.Name = "cb_Auditorium";
            this.cb_Auditorium.Size = new System.Drawing.Size(51, 15);
            this.cb_Auditorium.TabIndex = 10;
            this.cb_Auditorium.Text = "Dvorana";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(446, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Datum prikazivanja";
            // 
            // cb_Prikazivanja
            // 
            this.cb_Prikazivanja.FormattingEnabled = true;
            this.cb_Prikazivanja.Location = new System.Drawing.Point(446, 32);
            this.cb_Prikazivanja.Name = "cb_Prikazivanja";
            this.cb_Prikazivanja.Size = new System.Drawing.Size(121, 23);
            this.cb_Prikazivanja.TabIndex = 14;
            // 
            // frm_ReservationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1157, 622);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Prikazivanja);
            this.Controls.Add(this.gb_Rezervacije);
            this.Controls.Add(this.cb_Auditorium);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cb_Dvorana);
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
        private System.Windows.Forms.ComboBox cb_Dvorana;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label cb_Auditorium;
        private System.Windows.Forms.GroupBox gb_Rezervacije;
        private System.Windows.Forms.DataGridView dgv_Rezervacije;
        private System.Windows.Forms.Button btnSeatReservation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Prikazivanja;
    }
}