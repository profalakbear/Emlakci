using Business.Helpers;
using Business.ServiceContracts;
using Business.Services;
using Data;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsateApplication
{

    public partial class CreateNewEmlak : Form
    {
        private readonly IEstateAgentService _estateAgentService;
        private readonly ICategoryService _categoryService;
        private readonly IRoomService _roomService;
        private readonly IEstateService _estateService;
        List<Photo> photos = new List<Photo>();


        public CreateNewEmlak(IEstateAgentService estateAgentService, ICategoryService categoryService, IRoomService roomService, IEstateService estateService)
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
                createEmlakRoomCount.Items.Add(room.Name);
                createEmlakRoomCount.Tag = room.ID;
            }
        }

        public void PopulateCategories()
        {
            var categories = _categoryService.GetAll();
            foreach (var category in categories)
            {
                createEmlakCategories.Items.Add(category.Name);
                createEmlakCategories.Tag = category.ID;
            }
        }

        public void PopulateFloorCount()
        {
            for (int i = 1; i <= 30; i++)
            {
                createEmlakFloorCount.Items.Add(i.ToString());
            }
        }

        public void PopulateCurrentFloor()
        {
            for (int i = 1; i <= 30; i++)
            {
                createEmlakCurrentFloor.Items.Add(i.ToString());
            }
        }

        public void PopulateIsFurnished()
        {
            Dictionary<string, bool> isFurnishedMap = new Dictionary<string, bool>();
            isFurnishedMap.Add("Evet", true);  
            isFurnishedMap.Add("Hayir", false);

            foreach (var pair in isFurnishedMap)
            {
                createEmlakIsFurnished.Items.Add(pair.Key);
                createEmlakIsFurnished.Tag = pair.Value; 
            }
        }

        public void PopulateIsSale()
        {
            Dictionary<string, bool> isSaleMap = new Dictionary<string, bool>();
            isSaleMap.Add("Evet", true);    
            isSaleMap.Add("Hayir", false);  

            foreach (var pair in isSaleMap)
            {
                createEmlakIsSale.Items.Add(pair.Key);
                createEmlakIsSale.Tag = pair.Value; 
            }
        }

        public void PopulateIsRent()
        {
            Dictionary<string, bool> isRentMap = new Dictionary<string, bool>();
            isRentMap.Add("Evet", true);    
            isRentMap.Add("Hayir", false);  

            foreach (var pair in isRentMap)
            {
                createEmlakIsRent.Items.Add(pair.Key);
                createEmlakIsRent.Tag = pair.Value; 
            }
        }


        private void dropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string saveDirectory = ConfigurationManager.AppSettings["Photos"];

                foreach (string filename in openFileDialog.FileNames)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(filename);

                    string destinationPath = Path.Combine(saveDirectory, uniqueFileName);
                    File.Copy(filename, destinationPath);

                    Photo photo = new Photo
                    {
                        URL = destinationPath,
                        Name = uniqueFileName
                    };
                    photos.Add(photo);
                }
            }
        }

        private void createEmlakPost_Click(object sender, EventArgs e)
        {
            var x = createEmlakIsRent.Tag;
            var y = createEmlakIsSale.Tag;
            var z = createEmlakIsFurnished.Tag;
            var emlak = new Estate
            {
                EstateAgentID = SessionManager.UserId,
                Address = createEmlakAddres.Text,
                Price = int.Parse(createEmlakPrice.Text),
                IsSale = (bool)createEmlakIsRent.Tag,
                IsFurnished = (bool)createEmlakIsFurnished.Tag,
                IsRent = (bool)createEmlakIsSale.Tag,
                M2 = int.Parse(createEmlakM2.Text),
                EstateCategoryID = int.Parse(createEmlakCategories.Tag.ToString()),
                RoomID = int.Parse(createEmlakRoomCount.Tag.ToString()),
                TotalFloor = int.Parse(createEmlakFloorCount.SelectedItem.ToString()),
                Floor = int.Parse(createEmlakCurrentFloor.SelectedItem.ToString()),
            };

            var estate = _estateService.CreateAndReturnAsync(emlak);

            if (estate != null)
            {
                foreach (var photo in photos)
                {
                    photo.EstateID = estate.ID; 
                }

                estate.Photos = photos;

                var estateWithPhotos = _estateService.UpdateAsync(estate);

                if (estateWithPhotos != null)
                {

                    DialogResult res = MessageBox.Show("Ilan basariyla yayinlandi", "Ilan", MessageBoxButtons.OK);
                    if (res == DialogResult.OK)
                    {
                        ActiveForm.Close();
                        //EmlakciMain.ActiveForm.Refresh();

                    }
                }
            }
        }
    }
}
