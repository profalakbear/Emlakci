using Business.ServiceContracts;
using Data;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EsateApplication
{
    public partial class SignUp : Form
    {
        private readonly IUserService _userService;
        private readonly IEstateAgentService _estateAgentService;
        private readonly ICategoryService _categoryService;
        private readonly IRoomService _roomService;
        private readonly IEstateService _estateService;
        private readonly IPhotoService _photoService;
        public SignUp(
            IUserService userService, 
            IEstateAgentService estateAgentService, 
            ICategoryService categoryService, 
            IRoomService roomService, 
            IEstateService estateService,
            IPhotoService photoService
            )
        {
            InitializeComponent();
            _userService = userService;
            _estateAgentService = estateAgentService;
            _categoryService = categoryService;
            _roomService = roomService;
            _estateService = estateService;
            _photoService = photoService;
        }

        public TabControl SignupTabControl
        {
            get { return signUpTab; }
            set { signUpTab = value; }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                FirstName = signupFirstname.Text,
                LastName = signupLastname.Text,
                Email = signupEmail.Text,
                PhoneNumber = signupPhone.Text,
                Password = signupPassword.Text
            };

            var registeredUser = await _userService.RegisterAsync(user);
            if (registeredUser != null) {
                signupFirstname.Text = "";
                signupLastname.Text = "";
                signupEmail.Text = "";
                signupPhone.Text = "";
                signupPassword.Text = "";
                MessageBox.Show("Kullanici kaydi basarili. \n Giriş butonuna basarak giriş yapa bilirsiniz.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Form1 loginForm = new Form1(_userService, _estateAgentService, _categoryService, _roomService, _estateService, _photoService);
            loginForm.LoginTabControl.SelectedIndex = 0;
            loginForm.ShowDialog();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Form1 loginForm = new Form1(_userService, _estateAgentService, _categoryService, _roomService, _estateService, _photoService);
            loginForm.LoginTabControl.SelectedIndex = 1;
            loginForm.ShowDialog();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var estateAgent = new EstateAgent
            {
                BusinessName = signupEstateBusinessName.Text,
                AuthorizedPersonFirstName = signupEstateAuthorizedName.Text,
                AuthorizedPersonLastName = signupEstateAuthorizedSurname.Text,
                Email = signupEstateEmail.Text,
                Phone = signupEstatePhone.Text,
                Password = signupEstatePassword.Text,
                Address = signupEstateAddress.Text,
                Fax = signupEstateFax.Text,
                
            };

            var registeredUser = await _estateAgentService.RegisterAsync(estateAgent);
            if (registeredUser != null)
            {
                signupEstateBusinessName.Text = "";
                signupEstateAuthorizedName.Text = "";
                signupEstateAuthorizedSurname.Text = "";
                signupEstateEmail.Text = "";
                signupEstatePhone.Text = "";
                signupEstatePassword.Text = "";
                signupEstateAddress.Text = "";
                signupEstateFax.Text = "";
                MessageBox.Show("Emlakçı kaydi basarili. \n Giriş butonuna basarak giriş yapa bilirsiniz.");
            }
        }
    }
}
