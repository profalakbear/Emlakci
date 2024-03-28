using Business.ServiceContracts;
using Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsateApplication
{
    public partial class EmlakDetail : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly IRoomService _roomService;
        private readonly IEstateAgentService _estateAgentService;
        private Estate _estate;
        public EmlakDetail(Estate estate, ICategoryService categoryService, IRoomService roomService, IEstateAgentService estateAgentService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _roomService = roomService;
            _estateAgentService = estateAgentService;
            _estate = estate;
        }

        private void EmlakDetail_Load(object sender, EventArgs e)
        {
            var cat = _categoryService.GetById(_estate.EstateCategoryID);
            var room = _roomService.GetById(_estate.RoomID);
            emlakDetailAdres.Text = _estate.Address;
            emlakDetailFiyat.Text = _estate.Price.ToString();
            emlakDetailRent.Text = _estate.IsRent ? "Evet" : "Hayir";
            emlakDetailIsFurnished.Text = _estate.IsFurnished ? "Evet" : "Hayir";
            emlakDetailSale.Text = _estate.IsSale ? "Evet" : "Hayir";
            emlakDetailM2.Text = _estate.M2.ToString();
            emlakDetailFloorCount.Text = _estate.TotalFloor.ToString();
            emlakDetailFloor.Text = _estate.Floor.ToString();
            emlakDetailRoom.Text = room.Name;
            emlakDetailCategory.Text = cat.Name;
        }

        private void EmlakDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private async void emlakDetailPdfButton_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            Document document = new Document();
            var emlakci = await _estateAgentService.GetByIdAsync(_estate.EstateAgentID);

            try
            {
                // Create a SaveFileDialog instance
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "output.pdf"; // Default file name

                // Show the SaveFileDialog and get the result
                DialogResult result = saveFileDialog.ShowDialog();

                // Check if the user clicked OK in the dialog
                if (result == DialogResult.OK)
                {
                    // Get the selected file path from the dialog
                    string filePath = saveFileDialog.FileName;

                    // Create a PdfWriter instance to write to the PDF file
                    PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                    // Open the document
                    document.Open();

                    string details = $"Adres: {emlakDetailAdres.Text}{Environment.NewLine}" +
                     $"Fiyat: {emlakDetailFiyat.Text}{Environment.NewLine}" +
                     $"Kiralık: {emlakDetailRent.Text}{Environment.NewLine}" +
                     $"Mobilyalı: {emlakDetailIsFurnished.Text}{Environment.NewLine}" +
                     $"Satılık: {emlakDetailSale.Text}{Environment.NewLine}" +
                     $"Metrekare: {emlakDetailM2.Text}{Environment.NewLine}" +
                     $"Toplam Kat Sayısı: {emlakDetailFloorCount.Text}{Environment.NewLine}" +
                     $"Bulunduğu Kat: {emlakDetailFloor.Text}{Environment.NewLine}" +
                     $"Oda Sayısı: {emlakDetailRoom.Text}{Environment.NewLine}" +
                     $"Kategori: {emlakDetailCategory.Text}{Environment.NewLine}" +
                     $"Emlakci adi: {emlakci.AuthorizedPersonFirstName + " " + emlakci.AuthorizedPersonLastName}{Environment.NewLine}" +
                     $"Isletme adi : {emlakci.BusinessName}{Environment.NewLine}" +
                     $"Emlakci telefon: {emlakci.Phone}{Environment.NewLine}";
                    // Add content to the PDF
                    Paragraph paragraph = new Paragraph(details);
                    document.Add(paragraph);

                    // Close the document
                    document.Close();

                    // Show a message box indicating success
                    MessageBox.Show("PDF olusturulmasi basarili", "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Make sure to close the document if an exception occurs
                if (document.IsOpen())
                {
                    document.Close();
                }
            }
        }
    }
}
