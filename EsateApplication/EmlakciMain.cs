using Business.Helpers;
using Business.ServiceContracts;
using Business.Services;
using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsateApplication
{
    public partial class EmlakciMain : Form
    {
        private readonly IEstateAgentService _estateAgentService;
        private readonly ICategoryService _categoryService;
        private readonly IRoomService _roomService;
        private readonly IEstateService _estateService;
        private readonly IPhotoService _photoService;

        public EmlakciMain(IEstateAgentService estateAgentService, ICategoryService categoryService, IRoomService roomService, IEstateService estateService, IPhotoService photoService)
        {
            InitializeComponent();
            _estateAgentService = estateAgentService;
            _categoryService = categoryService;
            _roomService = roomService;
            _estateService = estateService;
            _photoService = photoService;

            PrepareEmlakciInfoSection();
            PrepareEmlakciEstatesSection();
        }

        public DataGridView DataGridView
        {
            get { return emlakciMainGrid; }
            set { emlakciMainGrid = value; }
        }

        public async void PrepareEmlakciInfoSection()
        {
            var estate = await _estateAgentService.GetByEmailAsync(SessionManager.Email);
            emlakMainName.Text = estate.AuthorizedPersonFirstName;
            emlakMainSurname.Text = estate.AuthorizedPersonLastName;
            emlakMainAddress.Text = estate.Address;
            emlakMainBusinessname.Text = estate.BusinessName;
            emlakMainFax.Text = estate.Fax;
            emlakMainPhone.Text = estate.Phone;
            emlakMainEmail.Text = estate.Email;
        }

        public async void PrepareEmlakciEstatesSection()
        {
            var estates = await _estateService.GetAllAsync();
            var agentEstates = estates.Where(e => e.EstateAgentID == SessionManager.UserId)
                                      .OrderByDescending(e => e.ID)
                                      .ToList();

            foreach (var estate in agentEstates)
            {
                // Add a new row to the DataGridView
                int rowIndex = emlakciMainGrid.Rows.Add();

                // Read image bytes from the first photo URL
                byte[] imageBytes = null;
                var firstPhoto = estate.Photos.FirstOrDefault();
                if (firstPhoto != null)
                {
                    imageBytes = ReadImageBytes(firstPhoto.URL);
                }

                // Set values for each cell in the row
                emlakciMainGrid.Rows[rowIndex].Cells[0].Value = imageBytes;
                emlakciMainGrid.Rows[rowIndex].Cells[1].Value = estate.ID; // Assuming MainResim is a byte[] containing image data
                emlakciMainGrid.Rows[rowIndex].Cells[2].Value = estate.Address;   // Assuming Address is a string property
                emlakciMainGrid.Rows[rowIndex].Cells[3].Value = estate.Price.ToString(); // Assuming Price is a decimal property

                // Add a button in the last column
                //DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                //buttonCell.Value = "See Details";
                emlakciMainGrid.Rows[rowIndex].Cells[4].Value = "Detaya git";
            }
        }

        private byte[] ReadImageBytes(string filePath)
        {
            try
            {
                // Read image bytes from file
                byte[] imageBytes = System.IO.File.ReadAllBytes(filePath);
                return imageBytes;
            }
            catch (Exception ex)
            {
                // Handle any exceptions related to reading the image file
                Console.WriteLine($"Error reading image file: {ex.Message}");
                return null;
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewEmlak newEmlak = new CreateNewEmlak(_estateAgentService, _categoryService, _roomService, _estateService);
            ActiveForm.Refresh();
            newEmlak.Show();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == emlakciMainGrid.Columns["emlakciMainDetayGrid"].Index && e.RowIndex >= 0)
            {
                var estateID = emlakciMainGrid.Rows[e.RowIndex].Cells["emlakMainIDGrid"].Value;
                var estate = await _estateService.GetByIdAsync((int)estateID);
                var emlakciDetail = new EmlakDetail(estate, _categoryService, _roomService, _estateAgentService);
                emlakciDetail.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            ActiveForm.Close();

        }
    }
}
