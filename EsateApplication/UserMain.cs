using Business.Helpers;
using Business.ServiceContracts;
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
    public partial class UserMain : Form
    {
        private readonly IEstateAgentService _estateAgentService;
        private readonly ICategoryService _categoryService;
        private readonly IRoomService _roomService;
        private readonly IEstateService _estateService;
        public UserMain(IEstateAgentService estateAgentService, ICategoryService categoryService, IRoomService roomService, IEstateService estateService)
        {
            InitializeComponent();

            _estateAgentService = estateAgentService;
            _categoryService = categoryService;
            _roomService = roomService;
            _estateService = estateService;

            LoadData();
        }

        private void LoadData()
        {
            PopulateRooms();
            PopulateCategories();
            PopulateFloorCount();
            PopulateCurrentFloor();
            PopulateIsRent();
            PopulateIsSale();
            PopulateIsFurnished();
        }

        public void PopulateRooms()
        {
            var rooms = _roomService.GetAll();
            foreach (var room in rooms)
            {
                createEmlakRoomCountUser.Items.Add(room.Name);
                createEmlakRoomCountUser.Tag = room.ID;
            }
        }

        public void PopulateCategories()
        {
            var categories = _categoryService.GetAll();
            foreach (var category in categories)
            {
                createEmlakCategoriesUser.Items.Add(category.Name);
                createEmlakCategoriesUser.Tag = category.ID;
            }
        }

        public void PopulateFloorCount()
        {
            for (int i = 1; i <= 30; i++)
            {
                createEmlakFloorCountUser.Items.Add(i.ToString());
            }
        }

        public void PopulateCurrentFloor()
        {
            for (int i = 1; i <= 30; i++)
            {
                createEmlakCurrentFloorUser.Items.Add(i.ToString());
            }
        }

        public void PopulateIsFurnished()
        {
            Dictionary<string, bool> isFurnishedMap = new Dictionary<string, bool>();
            isFurnishedMap.Add("Evet", true);
            isFurnishedMap.Add("Hayir", false);

            foreach (var pair in isFurnishedMap)
            {
                createEmlakIsFurnishedUser.Items.Add(pair.Key);
                createEmlakIsFurnishedUser.Tag = pair.Value;
            }
        }

        public void PopulateIsSale()
        {
            Dictionary<string, bool> isSaleMap = new Dictionary<string, bool>();
            isSaleMap.Add("Evet", true);
            isSaleMap.Add("Hayir", false);

            foreach (var pair in isSaleMap)
            {
                createEmlakIsSaleUser.Items.Add(pair.Key);
                createEmlakIsSaleUser.Tag = pair.Value;
            }
        }

        public void PopulateIsRent()
        {
            Dictionary<string, bool> isRentMap = new Dictionary<string, bool>();
            isRentMap.Add("Evet", true);
            isRentMap.Add("Hayir", false);

            foreach (var pair in isRentMap)
            {
                createEmlakIsRentUser.Items.Add(pair.Key);
                createEmlakIsRentUser.Tag = pair.Value;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var emlak = new Estate
            {
                Price = 0, //int.Parse(createEmlakPriceUser.Text),
                IsSale = false, //(bool)createEmlakIsRentUser.Tag,
                IsFurnished = false, //(bool)createEmlakIsFurnishedUser.Tag,
                IsRent = false, //(bool)createEmlakIsSaleUser.Tag,
                M2 = 0, //int.Parse(createEmlakM2User.Text),
                EstateCategoryID = 0, //int.Parse(createEmlakCategoriesUser.Tag.ToString()),
                RoomID = 0, //int.Parse(createEmlakRoomCountUser.Tag.ToString()),
                TotalFloor = 0, //int.Parse(createEmlakFloorCountUser.SelectedItem.ToString()),
                Floor = 0, //int.Parse(createEmlakCurrentFloorUser.SelectedItem.ToString()),
            };

            int price;
            if (int.TryParse(createEmlakPriceUser.Text, out price))
            {
                emlak.Price = price;
            }

            bool isSale;
            if (bool.TryParse(createEmlakIsRentUser.Tag.ToString(), out isSale))
            {
                emlak.IsSale = isSale;
            }

            bool isFurnished;
            if (bool.TryParse(createEmlakIsFurnishedUser.Tag.ToString(), out isFurnished))
            {
                emlak.IsFurnished = isFurnished;
            }

            bool isRent;
            if (bool.TryParse(createEmlakIsSaleUser.Tag.ToString(), out isRent))
            {
                emlak.IsRent = isRent;
            }

            int estateCategoryID;
            if (int.TryParse(createEmlakCategoriesUser.Tag.ToString(), out estateCategoryID))
            {
                emlak.EstateCategoryID = estateCategoryID;
            }

            int roomID;
            if (int.TryParse(createEmlakRoomCountUser.Tag.ToString(), out roomID))
            {
                emlak.RoomID = roomID;
            }

            int totalFloor;
            if (int.TryParse(createEmlakFloorCountUser.SelectedItem?.ToString(), out totalFloor))
            {
                emlak.TotalFloor = totalFloor;
            }

            int floor;
            if (int.TryParse(createEmlakCurrentFloorUser.SelectedItem?.ToString(), out floor))
            {
                emlak.Floor = floor;
            }

            var estates = await _estateService.GetAllAsync();
            var filteredEstates = estates.Where(es =>
              (es.IsSale == emlak.IsSale) &&
              (es.IsRent == emlak.IsRent) &&
              (es.IsFurnished == emlak.IsFurnished) &&
              (emlak.RoomID == 0 || es.RoomID == emlak.RoomID) && 
              (emlak.TotalFloor == 0 || es.TotalFloor == emlak.TotalFloor) && 
              (emlak.Floor == 0 || es.Floor == emlak.Floor) 
          ).ToList();

            foreach (var estate in filteredEstates)
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

        private void UserMain_Load(object sender, EventArgs e)
        {

        }

        private async void emlakciMainGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == emlakciMainGrid.Columns["emlakciMainDetayGrid"].Index && e.RowIndex >= 0)
            {
                var estateID = emlakciMainGrid.Rows[e.RowIndex].Cells["emlakMainIDGrid"].Value;
                var estate = await _estateService.GetByIdAsync((int)estateID);
                var emlakciDetail = new EmlakDetail(estate, _categoryService, _roomService, _estateAgentService);
                emlakciDetail.Show();
            }
        }
    }
}
