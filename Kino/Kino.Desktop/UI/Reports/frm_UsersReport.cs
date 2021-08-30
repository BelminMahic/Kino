using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Kino.Desktop.UI.Reports
{
    public partial class frm_UsersReport : Form
    {

        private readonly APIService _userService = new APIService("user");

        public frm_UsersReport()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
               
                var result = await _userService.Get<List<Model.User>>(null);

                dgvKorisnici.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Korisnici", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CreatePDF(DataGridView dgv, string fileName)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);

            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

            foreach (DataGridViewColumn item in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(item.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            foreach (DataGridViewRow item in dgv.Rows)
            {
                foreach (DataGridViewCell cell in item.Cells)
                {
                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }

            var saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = fileName;
            saveFileDialog.DefaultExt = ".pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdfTable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            CreatePDF(dgvKorisnici, "IzvjestajOKorisnicima");
        }
    }
}
